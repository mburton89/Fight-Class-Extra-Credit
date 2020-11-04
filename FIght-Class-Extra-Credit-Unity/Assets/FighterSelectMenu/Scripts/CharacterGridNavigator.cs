using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGridNavigator : MonoBehaviour
{
    private List<SelectableThumbnail> _characters;
    private SelectableThumbnail _currentCharacter;
    private int _currentIndex;
    public bool isPlayer1;

    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;

    public void Init(List<SelectableThumbnail> characters)
    {
        _characters = characters;
        _currentIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(_up))
        {
            NavigateUp();
        }
        else if (Input.GetKeyDown(_down))
        {
            NavigateDown();
        }
        else if (Input.GetKeyDown(_left))
        {
            NavigateLeft();
        }
        else if (Input.GetKeyDown(_right))
        {
            NavigateRight();
        }
    }

    void NavigateUp()
    {
        if (_currentIndex == 0 || _currentIndex == 1 || _currentIndex == 2) return;
        _characters[_currentIndex].Deselect(isPlayer1);
        _currentIndex = _currentIndex - 3;
        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    void NavigateDown()
    {
        if (_currentIndex > 5) return;
        _characters[_currentIndex].Deselect(isPlayer1);
        _currentIndex = _currentIndex + 3;
        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    void NavigateLeft()
    {
        if (_currentIndex == 0 || _currentIndex == 3 || _currentIndex == 6) return;
        _characters[_currentIndex].Deselect(isPlayer1);
        _currentIndex = _currentIndex - 1;
        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    void NavigateRight()
    {
        if (_currentIndex == 2 || _currentIndex == 5 || _currentIndex == 8) return;
        _characters[_currentIndex].Deselect(isPlayer1);
        _currentIndex = _currentIndex + 1;
        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    public void HandleSelected()
    {
        if (isPlayer1)
        {
            FighterSelectSceneController.Instance.p1CharacterIndex = _currentIndex;
        }
        else
        {
            FighterSelectSceneController.Instance.p2CharacterIndex = _currentIndex;
        }
    }
}
