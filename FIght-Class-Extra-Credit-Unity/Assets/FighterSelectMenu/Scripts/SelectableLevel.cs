using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableLevel : MonoBehaviour
{
    [SerializeField] private Image _levelImage;
    [SerializeField] private Button _button;

    private int _levelIndex;

    [SerializeField] private GameObject _tab;

    public void Init(int _levelIndex, Transform parent)
    {
        _levelImage.sprite = DataReferenceManager.Instance.levelImages[_levelIndex];
        transform.SetParent(parent);
        transform.localScale = Vector3.one;
    }

    public void Select()
    {
        _button.Select();
        _tab.SetActive(true);
    }

    public void Deselect()
    {
        _tab.SetActive(false);
    }
}
