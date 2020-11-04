using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeNavigator : MonoBehaviour
{
    public static HomeNavigator Instance;

    [SerializeField] private List<HomeButton> _homeButtons;
    private HomeButton _selectedHomeButton;
    private int _currentIndex;

    [SerializeField] private GameObject _creditsMenu;
    [SerializeField] private GameObject _optionsMenu;

    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;

    [SerializeField] private KeyCode _up2;
    [SerializeField] private KeyCode _down2;

    [SerializeField] private KeyCode _confirm;

    [HideInInspector] public bool isOnCreditsMenu;
    [HideInInspector] public bool isOnOptionsMenu;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _selectedHomeButton = _homeButtons[_currentIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(_up) || Input.GetKeyDown(_up2))
        {
            NavigateUp();
        }
        else if (Input.GetKeyDown(_down) || Input.GetKeyDown(_down2))
        {
            NavigateDown();
        }
        else if (Input.GetKeyDown(_confirm))
        {
            if (isOnCreditsMenu || isOnOptionsMenu)
            {
                CloseCreditsMenu();
                CloseOptionsMenu();
            }
            else
            {
                _selectedHomeButton.HandleSelect();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCreditsMenu();
            CloseOptionsMenu();
        }
    }

    void NavigateUp()
    {
        if (_currentIndex == 0) return;
        _homeButtons[_currentIndex].Deselect();
        _currentIndex = _currentIndex - 1;
        _homeButtons[_currentIndex].Select();
        _selectedHomeButton = _homeButtons[_currentIndex];
        MenuSFX.Instance.Click();
    }

    void NavigateDown()
    {
        if (_currentIndex >= _homeButtons.Count - 1) return;
        _homeButtons[_currentIndex].Deselect();
        _currentIndex = _currentIndex + 1;
        _homeButtons[_currentIndex].Select();
        _selectedHomeButton = _homeButtons[_currentIndex];
        MenuSFX.Instance.Click();
    }

    public void MarkButtonSelected(HomeButton selectedButton)
    {
        _homeButtons[_currentIndex].Deselect();
        _currentIndex = _homeButtons.IndexOf(selectedButton);
        selectedButton.Select();
        _selectedHomeButton = _homeButtons[_currentIndex];
    }

    public void GoToCharacterSelect()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenCreditsMenu()
    {
        _creditsMenu.SetActive(true);
        isOnCreditsMenu = true;
    }

    public void CloseCreditsMenu()
    {
        _creditsMenu.SetActive(false);
        isOnCreditsMenu = false;
    }

    public void OpenOptionsMenu()
    {
        _optionsMenu.SetActive(true);
        isOnOptionsMenu = true;
    }

    public void CloseOptionsMenu()
    {
        _optionsMenu.SetActive(false);
        isOnOptionsMenu = false;
    }
}
