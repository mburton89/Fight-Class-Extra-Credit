using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGridNavigator : MonoBehaviour
{
    [SerializeField] private CharacterSelectMenu _menu;
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
        _characters[_currentIndex].Deselect(isPlayer1);
        if (_menu.currentYear == 0)
        {
            if (_currentIndex == 0 || _currentIndex == 1 || _currentIndex == 2)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex = _currentIndex - 3;
        }
        else if (_menu.currentYear == 1)
        {
            if (_currentIndex < 3)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex -= 3;
        }
        
        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    void NavigateDown()
    {
        _characters[_currentIndex].Deselect(isPlayer1);
        if (_menu.currentYear == 0)
        {
            if (_currentIndex > 5)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex = _currentIndex + 3;
        }
        else if (_menu.currentYear == 1)
        {
            if (_currentIndex > 2)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex += 3;
        }

        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    void NavigateLeft()
    {
        _characters[_currentIndex].Deselect(isPlayer1);
        if (_menu.currentYear == 0)
        {
            if (_currentIndex == 0 || _currentIndex == 3 || _currentIndex == 6)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex = _currentIndex - 1;
        }
        else if (_menu.currentYear == 1)
        {
            if (_currentIndex == 0 || _currentIndex == 3)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex -= 1;
        }

        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    void NavigateRight()
    {
        _characters[_currentIndex].Deselect(isPlayer1);
        if (_menu.currentYear == 0)
        {
            if (_currentIndex == 2 || _currentIndex == 5 || _currentIndex == 8)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex = _currentIndex + 1;
        }
        else if (_menu.currentYear == 1)
        {
            if (_currentIndex == 2 || _currentIndex == 5)
            {
                _characters[_currentIndex].Select(isPlayer1);
                return;
            }
            _currentIndex += 1;
        }

        _characters[_currentIndex].Select(isPlayer1);
        MenuSFX.Instance.Click();
    }

    public void HandleSelected()
    {
        int _selected = _currentIndex + (9 * _menu.currentYear);
        if (_selected == 14)
        {
            _selected = (int) Random.Range(0, DataReferenceManager.Instance.characterNames.Count - 1);
        }

        Debug.Log("Currently selected: " + _selected);

        if (isPlayer1)
        {
            FighterSelectSceneController.Instance.p1CharacterIndex = _selected;
        }
        else
        {
            FighterSelectSceneController.Instance.p2CharacterIndex = _selected;
        }
    }
}
