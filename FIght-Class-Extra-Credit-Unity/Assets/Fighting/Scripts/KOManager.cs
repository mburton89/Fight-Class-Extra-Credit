using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class KOManager : MonoBehaviour
{
    public static KOManager Instance;

    [SerializeField] private Sprite fMinus;
    [SerializeField] private Sprite aPlus;
    [SerializeField] private Image p1Grade;
    [SerializeField] private Image p2Grade;
    [SerializeField] private Transform koImage;
    [SerializeField] private Transform readyImage;
    [SerializeField] private Transform fightImage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip koVo;
    [SerializeField] private AudioClip readyVo;
    [HideInInspector] public FighterAnimationController p1;
    [HideInInspector] public FighterAnimationController p2;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(IntroCo());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void ShowWin(bool isPlayerOne)
    {
        if (isPlayerOne)
        {
            p1Grade.sprite = aPlus;
            p2Grade.sprite = fMinus;
            p2.TwirlAway();
        }
        else
        {
            p2Grade.sprite = aPlus;
            p1Grade.sprite = fMinus;
            p1.TwirlAway();
        }

        p1Grade.transform.DOShakeScale(1, 1, 10, 90, true);
        p2Grade.transform.DOShakeScale(1, 1, 10, 90, true);
        koImage.DOScale(1, .5f).SetEase(Ease.OutBounce);
        koImage.DORotate(new Vector3(0,0,720), .5f, RotateMode.Fast);
        audioSource.clip = koVo;
        audioSource.Play();
        StartCoroutine(ExitCo());
    }

    private IEnumerator IntroCo()
    {
        readyImage.DOScale(1, .5f).SetEase(Ease.OutBounce);
        audioSource.clip = readyVo;
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        readyImage.localScale = Vector3.zero;
        fightImage.DOScale(1, .5f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1f);
        fightImage.DOScale(0, .5f);
    }

    private IEnumerator ExitCo()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);
    }
}
