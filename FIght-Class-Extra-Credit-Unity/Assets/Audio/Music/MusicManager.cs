using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public List<AudioClip> tracks;
    [HideInInspector] public AudioSource musicAudioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            musicAudioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectTrack(int index)
    {
        musicAudioSource.clip = tracks[index];
        musicAudioSource.Play();
    }
}
