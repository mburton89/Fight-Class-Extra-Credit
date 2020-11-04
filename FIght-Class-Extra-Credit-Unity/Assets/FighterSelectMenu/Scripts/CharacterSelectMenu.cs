using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
    [SerializeField] private SelectableThumbnail _selectableThumbnailPrefab;
    [SerializeField] private GridLayoutGroup _grid;

    private List<SelectableThumbnail> _allThumbnails = new List<SelectableThumbnail>();

    [SerializeField] private CharacterGridNavigator _player1Navigator;
    [SerializeField] private CharacterGridNavigator _player2Navigator;

    void Start()
    {
        for (int i = 0; i < DataReferenceManager.Instance.characterNames.Count; i++)
        {
            SelectableThumbnail newThumbnail = Instantiate(_selectableThumbnailPrefab);
            newThumbnail.transform.SetParent(_grid.transform);
            newThumbnail.Init(this, i, _grid.transform);
            _allThumbnails.Add(newThumbnail);
        }

        _allThumbnails[0].Select(true);
        _allThumbnails[0].Select(false);

        _player1Navigator.Init(_allThumbnails);
        _player2Navigator.Init(_allThumbnails);
    }
}
