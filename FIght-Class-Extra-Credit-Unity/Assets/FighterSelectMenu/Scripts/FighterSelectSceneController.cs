using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FighterSelectSceneController : MonoBehaviour
{
    public static FighterSelectSceneController Instance;

    [SerializeField] private GameObject _characterSelectContainer;
    [SerializeField] private GameObject _levelSelectContainer;

    [SerializeField] private CharacterPreview _player1Preview;
    [SerializeField] private CharacterPreview _player2Preview;

    [SerializeField] private CharacterGridNavigator _player1Nav;
    [SerializeField] private CharacterGridNavigator _player2Nav;
    [SerializeField] private LevelGridNavigator _levelNav;

    [HideInInspector] public bool isOnCharacterSelect;

    [SerializeField] private KeyCode _back;
    [SerializeField] private KeyCode _confirm;

    [HideInInspector] public int p1CharacterIndex;
    [HideInInspector] public int p2CharacterIndex;
    [HideInInspector] public int levelIndex;

    [SerializeField] private AudioSource audio;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        isOnCharacterSelect = true;
    }

    private void Start()
    {
        if (MusicManager.Instance.musicAudioSource.clip != MusicManager.Instance.tracks[4])
        {
            MusicManager.Instance.musicAudioSource.clip = MusicManager.Instance.tracks[4];
            MusicManager.Instance.musicAudioSource.Play();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_confirm))
        {
            if (isOnCharacterSelect)
            {
                _player1Nav.HandleSelected();
                _player2Nav.HandleSelected();
                _characterSelectContainer.SetActive(false);
                _levelSelectContainer.SetActive(true);
                isOnCharacterSelect = false;
                StartCoroutine(confirmAudio());
            }
            else
            {
                _levelNav.HandleSelected();
                print("START FIGHT. " + 
                    "p1CharacterIndex: " + p1CharacterIndex + " | " +
                    "p2CharacterIndex: " + p2CharacterIndex + " | " +
                    "levelIndex: " + levelIndex);

                DataReferenceManager.Instance.p1Index = p1CharacterIndex;
                DataReferenceManager.Instance.p2Index = p2CharacterIndex;
                DataReferenceManager.Instance.levelIndex = levelIndex;
                SceneManager.LoadScene(3);
            }
        }
        else if (Input.GetKeyDown(_back))
        {
            if (!isOnCharacterSelect)
            {
                _characterSelectContainer.SetActive(true);
                _levelSelectContainer.SetActive(false);
                isOnCharacterSelect = true;
                _player1Preview.PlayIdleAnimation();
                _player2Preview.PlayIdleAnimation();
            }
        }
    }

    public void UpdatePlayer1Preview(int index)
    {
        _player1Preview.UpdateCharacterPose(index);
    }

    public void UpdatePlayer2Preview(int index)
    {
        _player2Preview.UpdateCharacterPose(index);
    }

    private IEnumerator confirmAudio()
    {
        audio.clip = DataReferenceManager.Instance.characterConfirmVO[p1CharacterIndex];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = DataReferenceManager.Instance.characterConfirmVO[p2CharacterIndex];
        audio.Play();
    }
}
