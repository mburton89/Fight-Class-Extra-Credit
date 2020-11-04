using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public static IntroController Instance;

    [SerializeField] private Button _overlayButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SkipScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SkipScene();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            MusicManager.Instance.musicAudioSource.Play();
            SceneManager.LoadScene(0);
        }
    }

    private void OnEnable()
    {
        _overlayButton.onClick.AddListener(SkipScene);
    }

    private void OnDisable()
    {
        _overlayButton.onClick.RemoveListener(SkipScene);
    }

    public void SkipScene()
    {
        SceneManager.LoadScene(1);
    }
}
