using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectableThumbnail : MonoBehaviour
{
    private CharacterSelectMenu _characterSelectMenu;

    [SerializeField] private Image _characterThumbnail;
    [SerializeField] private Button _button;

    private int _characterIndex;

    [SerializeField] private GameObject _p1Tab;
    [SerializeField] private GameObject _p2Tab;

    public void Init(CharacterSelectMenu characterSelectMenu, int characterIndex, Transform parent)
    {
        _characterSelectMenu = characterSelectMenu;
        _characterIndex =  characterIndex;
        _characterThumbnail.sprite = DataReferenceManager.Instance.characterThumbnails[characterIndex];
        transform.SetParent(parent);
        transform.localScale = Vector3.one;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UpdateCharacterPreview);
    }

    void UpdateCharacterPreview()
    {
        FighterSelectSceneController.Instance.UpdatePlayer1Preview(_characterIndex);
    }

    public void Select(bool isPlayer1)
    {
        if (isPlayer1)
        {
            _button.Select();
            FighterSelectSceneController.Instance.UpdatePlayer1Preview(_characterIndex);
            _p1Tab.SetActive(true);
        }
        else
        {
            _button.Select();
            FighterSelectSceneController.Instance.UpdatePlayer2Preview(_characterIndex);
            _p2Tab.SetActive(true);
        }
    }

    public void Deselect(bool isPlayer1)
    {
        if (isPlayer1)
        {
            _p1Tab.SetActive(false);
        }
        else
        {
            _p2Tab.SetActive(false);
        }
    }
}
