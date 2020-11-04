using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private FighterAnimationController _controller;

    private AudioSource _sfxSource;

    [SerializeField]private List<AudioClip> _sfx = new List<AudioClip>();

    public bool isBlocking;

    public void Init(FighterAnimationController controller)
    {
        _controller = controller;
        _sfxSource = gameObject.AddComponent<AudioSource>();
        _sfx.Add(Resources.Load("punch-sfx") as AudioClip);
        _sfx.Add(Resources.Load("kick-sfx") as AudioClip);
        _sfx.Add(Resources.Load("block-sfx") as AudioClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OOF" + collision.name);

        if (collision.name == "KickBox(Clone)")
        {
            PlayKickSound();
            _controller.DecrementHealth();
        }
        else
        {
            if (isBlocking)
            {
                PlayBlockSound();
            }
            else
            {
                PlayPunchSound();
                _controller.DecrementHealth();
            }
        }
    }

    public void PlayPunchSound()
    {
        _sfxSource.clip = _sfx[0];
        _sfxSource.Play();
    }

    public void PlayKickSound()
    {
        _sfxSource.clip = _sfx[1];
        _sfxSource.Play();
    }

    public void PlayBlockSound()
    {
        _sfxSource.clip = _sfx[2];
        _sfxSource.Play();
    }
}
