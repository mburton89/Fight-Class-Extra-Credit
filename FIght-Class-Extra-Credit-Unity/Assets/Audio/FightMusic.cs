using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMusic : MonoBehaviour
{
    public static FightMusic Instance;

    [SerializeField] private List<AudioClip> _tracks;
    private AudioSource _audio;

    private void Awake()
    {
        Instance = this;
        _audio = GetComponent<AudioSource>();
    }

    public void SelectTrack(int index)
    {
        _audio.clip = _tracks[index];
        _audio.Play();
    }
}
