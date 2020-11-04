using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    public static MenuSFX Instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        _audioSource.Play();
    }
}
