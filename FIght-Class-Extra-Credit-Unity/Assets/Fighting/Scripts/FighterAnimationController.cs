using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FighterAnimationController : MonoBehaviour
{
    public SpriteRenderer currentFrame;

    public List<Sprite> idleSprites;
    public List<Sprite> lightPunchSprites;
    public List<Sprite> lightKickSprites;
    //public List<Sprite> strongPunchSprites;
    //public List<Sprite> strongKickSprites;
    public List<Sprite> jumpSprites;
    public Sprite blockSprite;

    public float idleFrameDuration = 0.25f;
    public float punchFrameDuration = 0.15f;
    public float blockFrameDuration = 0.25f;
    public float jumpDurationMultiplier = 2.5f;
    public float jumpHeight = 3.5f;

    public Ease jumpUpEase = Ease.OutCirc;
    public Ease jumpDownEase = Ease.InCirc;

    private Coroutine _currentCoroutine = null;
    private bool _canAttack;
    private bool _isBlocking;

    private KeyCode moveLeft;
    private KeyCode moveRight;
    private KeyCode jump;
    private KeyCode block;
    private KeyCode punch;
    private KeyCode kick;

    private bool _isP1;

    [SerializeField] private Body _body;

    private float _punchDistance = 3.2f;
    private float _punchHeight = 1.8f;

    public float _kickDistance = 3.2f;
    public float _kickHeight = -1.8f;

    private Vector3 _currentPosition = new Vector3();
    private Vector3 _punchPosition = new Vector3();
    private Vector3 _kickPosition = new Vector3();

    private AudioSource _sfxSource;

    [SerializeField] private List<AudioClip> _sfx = new List<AudioClip>();

    public bool isTestMode;

    private void Awake()
    {
        _body = GetComponentInParent<Body>();

        _sfxSource = gameObject.AddComponent<AudioSource>();
        _sfx.Add(Resources.Load("punch-woosh") as AudioClip);
        _sfx.Add(Resources.Load("kick-woosh") as AudioClip);
        _sfx.Add(Resources.Load("jump-sfx") as AudioClip);

        EstablishP1Controls();
    }

    public void Start()
    {
        _currentCoroutine = StartCoroutine(IdleAnimation());

        if (GetComponentInParent<Body>() != null)
        {
            _body = GetComponentInParent<Body>();
            _body.Init(this);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(punch) && _canAttack)
        {
            StopCoroutine(_currentCoroutine);
            PlayLightPunchAnimation();
        }
        else if (Input.GetKeyDown(kick) && _canAttack)
        {
            StopCoroutine(_currentCoroutine);
            PlayLightKickAnimation();
        }
        //else if (Input.GetKeyDown(block) && _canAttack)
        //{
        //    StopCoroutine(_currentCoroutine);
        //    PlayBlockAnimation();
        //}
        else if (Input.GetKeyDown(block) && _canAttack)
        {
            StopCoroutine(_currentCoroutine);
            StartBlock();
        }
        else if (Input.GetKeyUp(block))
        {
            Unblock();
        }
        else if (Input.GetKeyDown(jump) && _canAttack)
        {
            StopCoroutine(_currentCoroutine);
            PlayJumpAnimation();
        }

        //InstLocRight = ((hurtbox.transform.position) + new Vector3(1f + punchDistance, 0.5f, 0));
        //InstLocLeft = ((hurtbox.transform.position) + new Vector3(-1f - punchDistance, 0.5f, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OUCHIE");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OOF");
    }

    public void PlayIdleAnimation()
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(IdleAnimation());
    }

    public void PlayLightPunchAnimation()
    {
        StartCoroutine(LightPunchAnimation());
    }

    public void PlayLightKickAnimation()
    {
        StartCoroutine(LightKickAnimation());
    }

    public void PlayBlockAnimation()
    {
        StartCoroutine(Block());
    }

    public void PlayJumpAnimation()
    {
        StartCoroutine(JumpAnimation());
    }

    private IEnumerator IdleAnimation()
    {
        _canAttack = true;
        currentFrame.sprite = idleSprites[0];
        yield return new WaitForSeconds(idleFrameDuration);
        currentFrame.sprite = idleSprites[1];
        yield return new WaitForSeconds(idleFrameDuration);
        currentFrame.sprite = idleSprites[2];
        yield return new WaitForSeconds(idleFrameDuration);
        PlayIdleAnimation();
    }

    private IEnumerator LightPunchAnimation()
    {
        _canAttack = false;
        currentFrame.sprite = lightPunchSprites[0];
        PlayPunchWoosh();
        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = lightPunchSprites[1];
        _currentPosition = transform.position;

        if (transform.localScale.x < 0)
        {
            _punchPosition = new Vector3(_currentPosition.x - _punchDistance, _currentPosition.y + _punchHeight, 1);
        }
        else
        {
            _punchPosition = new Vector3(_currentPosition.x + _punchDistance, _currentPosition.y + _punchHeight, 1);
        }

        GameObject punchBox = Instantiate((GameObject)Resources.Load("PunchBox"), _punchPosition, Quaternion.identity);
        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = lightPunchSprites[2];
        Destroy(punchBox);
        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = lightPunchSprites[3];
        yield return new WaitForSeconds(punchFrameDuration);
        PlayIdleAnimation();
    }

    private IEnumerator LightKickAnimation()
    {
        _canAttack = false;
        currentFrame.sprite = lightKickSprites[0];
        PlayKickWoosh();
        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = lightKickSprites[1];

        _currentPosition = transform.position;

        if (transform.localScale.x < 0)
        {
            _kickPosition = new Vector3(_currentPosition.x - _kickDistance, _currentPosition.y + _kickHeight, 1);
        }
        else
        {
            _kickPosition = new Vector3(_currentPosition.x + _kickDistance, _currentPosition.y + _kickHeight, 1);
        }

        GameObject kickBox = Instantiate((GameObject)Resources.Load("KickBox"), _kickPosition, Quaternion.identity);

        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = lightKickSprites[2];
        Destroy(kickBox);
        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = lightKickSprites[3];
        yield return new WaitForSeconds(punchFrameDuration);
        PlayIdleAnimation();
    }

    //private IEnumerator PlayPunchHeavy()
    //{
    //    _canAttack = false;
    //    currentFrame.sprite = strongPunchSprites[0];
    //    yield return new WaitForSeconds(punchFrameDuration);
    //    currentFrame.sprite = strongPunchSprites[1];
    //    yield return new WaitForSeconds(punchFrameDuration);
    //    currentFrame.sprite = strongPunchSprites[2];
    //    yield return new WaitForSeconds(punchFrameDuration);
    //    currentFrame.sprite = strongPunchSprites[3];
    //    yield return new WaitForSeconds(punchFrameDuration);
    //    currentFrame.sprite = strongPunchSprites[4];
    //    yield return new WaitForSeconds(punchFrameDuration);
    //    currentFrame.sprite = strongPunchSprites[5];
    //    yield return new WaitForSeconds(punchFrameDuration);
    //    PlayIdleAnimation();
    //}

    private IEnumerator JumpAnimation()
    {
        _canAttack = false;
        currentFrame.sprite = jumpSprites[0];
        yield return new WaitForSeconds(punchFrameDuration);
        currentFrame.sprite = jumpSprites[1];
        PlayJumpSound();
        _canAttack = true;

        if (isTestMode)
        {
            currentFrame.transform.DOMoveY(currentFrame.transform.position.y + jumpHeight, (punchFrameDuration * jumpDurationMultiplier), false).SetEase(jumpUpEase);
        }

        yield return new WaitForSeconds(punchFrameDuration * jumpDurationMultiplier);

        if (isTestMode)
        {
            currentFrame.transform.DOMoveY(currentFrame.transform.position.y - jumpHeight, (punchFrameDuration * jumpDurationMultiplier) / 2, false).SetEase(jumpDownEase);
        }

        yield return new WaitForSeconds(punchFrameDuration * jumpDurationMultiplier);
        PlayIdleAnimation();
    }

    private IEnumerator Block()
    {
        _canAttack = false;
        _isBlocking = true;
        currentFrame.sprite = blockSprite;
        yield return new WaitForSeconds(blockFrameDuration);
        _isBlocking = false;
        PlayIdleAnimation();
    }

    private void StartBlock()
    {
        if (_body != null)
        {
            _body.isBlocking = true;
        }
        _canAttack = false;
        _isBlocking = true;
        currentFrame.sprite = blockSprite;
    }

    private void Unblock()
    {
        if (_body != null)
        {
            _body.isBlocking = false;
        }
        _isBlocking = false;
        PlayIdleAnimation();
    }

    public void EstablishP1Controls()
    {
        _isP1 = true;
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
        jump = KeyCode.W;
        block = KeyCode.S;
        punch = KeyCode.F;
        kick = KeyCode.G;
    }

    public void EstablishP2Controls()
    {
        _isP1 = false;
        moveLeft = KeyCode.LeftArrow;
        moveRight = KeyCode.RightArrow;
        jump = KeyCode.UpArrow;
        block = KeyCode.DownArrow;
        punch = KeyCode.Keypad1;
        kick = KeyCode.Keypad2;
    }

    public void DecrementHealth()
    {
        if (_isP1)
        {
            HealthManager.Instance.DecreaseP1Health(.1f);
        }
        else
        {
            HealthManager.Instance.DecreaseP2Health(.1f);
        }
    }

    public void PlayPunchWoosh()
    {
        _sfxSource.clip = _sfx[0];
        _sfxSource.Play();
    }

    public void PlayKickWoosh()
    {
        _sfxSource.clip = _sfx[1];
        _sfxSource.Play();
    }

    public void PlayJumpSound()
    {
        _sfxSource.clip = _sfx[2];
        _sfxSource.Play();
    }

    public void TwirlAway()
    {
        transform.DOMove(new Vector3(10f, 10f, 1f), 1f, false);
        transform.DORotate(new Vector3(0, 0, 900f), 1f, RotateMode.Fast);
    }
}

