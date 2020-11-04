using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGridNavigator : MonoBehaviour
{
    private List<SelectableLevel> _levels;
    private SelectableLevel _currentLevel;
    private int _currentIndex;

    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;

    [SerializeField] private KeyCode _up2;
    [SerializeField] private KeyCode _down2;
    [SerializeField] private KeyCode _left2;
    [SerializeField] private KeyCode _right2;

    public void Init(List<SelectableLevel> levels)
    {   
        _levels = levels;
        _currentIndex = 0;
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
        else if (Input.GetKeyDown(_left) || Input.GetKeyDown(_left2))
        {
            NavigateLeft();
        }
        else if (Input.GetKeyDown(_right) || Input.GetKeyDown(_right2))
        {
            NavigateRight();
        }
    }

    void NavigateUp()
    {
        if (_currentIndex == 0 || _currentIndex == 1) return;
        _levels[_currentIndex].Deselect();
        _currentIndex = _currentIndex - 2;
        _levels[_currentIndex].Select();
        MenuSFX.Instance.Click();
    }

    void NavigateDown()
    {
        if (_currentIndex > 1) return;
        _levels[_currentIndex].Deselect();
        _currentIndex = _currentIndex + 2;
        _levels[_currentIndex].Select();
        MenuSFX.Instance.Click();
    }

    void NavigateLeft()
    {
        if (_currentIndex == 0 || _currentIndex == 2) return;
        _levels[_currentIndex].Deselect();
        _currentIndex = _currentIndex - 1;
        _levels[_currentIndex].Select();
        MenuSFX.Instance.Click();
    }

    void NavigateRight()
    {
        if (_currentIndex == 1 || _currentIndex == 3) return;
        _levels[_currentIndex].Deselect();
        _currentIndex = _currentIndex + 1;
        _levels[_currentIndex].Select();
        MenuSFX.Instance.Click();
    }

    public void HandleSelected()
    {
        FighterSelectSceneController.Instance.levelIndex = _currentIndex;
    }
}
