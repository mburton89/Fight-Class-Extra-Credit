using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{

    public int currentYear = 1; 

    [SerializeField] private SelectableThumbnail _selectableThumbnailPrefab;
    [SerializeField] private GridLayoutGroup _grid2019;
    [SerializeField] private GridLayoutGroup _grid2020;

    private List<SelectableThumbnail> _2019Thumbnails = new List<SelectableThumbnail>();
    private List<SelectableThumbnail> _2020Thumbnails = new List<SelectableThumbnail>();

    [SerializeField] private CharacterGridNavigator _player1Navigator;
    [SerializeField] private CharacterGridNavigator _player2Navigator;

    void Start()
    {
        /*for (int i = 0; i < DataReferenceManager.Instance.characterNames.Count; i++)
        {
            SelectableThumbnail newThumbnail = Instantiate(_selectableThumbnailPrefab);
            newThumbnail.transform.SetParent(_grid.transform);
            newThumbnail.Init(this, i, _grid.transform);
            _2019Thumbnails.Add(newThumbnail);
        }

        _2019Thumbnails[0].Select(true);
        _2019Thumbnails[0].Select(false);

        _player1Navigator.Init(_2019Thumbnails);
        _player2Navigator.Init(_2019Thumbnails); */

        Initialize2019();
        Initialize2020();

        SwitchYear(currentYear);
    }

    public void SwitchYear(int index)
    {
        Debug.Log(index);
        if (index == 0) // Year 2019
        {
            _2019Thumbnails[0].Select(true);
            _2019Thumbnails[0].Select(false);

            _player1Navigator.Init(_2019Thumbnails);
            _player2Navigator.Init(_2019Thumbnails);

            _grid2019.enabled = true;
        }
        else if (index == 1) // Year 2020
        {
            _2020Thumbnails[0].Select(true);
            _2020Thumbnails[0].Select(false);

            _player1Navigator.Init(_2020Thumbnails);
            _player2Navigator.Init(_2020Thumbnails);

            _grid2020.enabled = true;
        }
    }

    private void Initialize2019()
    {
        for (int i = 0; i < 9; i++)
        {
            SelectableThumbnail newThumbnail = Instantiate(_selectableThumbnailPrefab);
            newThumbnail.transform.SetParent(_grid2019.transform);
            newThumbnail.Init(this, i, _grid2019.transform);
            _2019Thumbnails.Add(newThumbnail);
        }

        _grid2019.enabled = false;

    }

    private void Initialize2020()
    {
        for (int i = 9; i < DataReferenceManager.Instance.characterNames.Count; i++)
        {
            SelectableThumbnail newThumbnail = Instantiate(_selectableThumbnailPrefab);
            newThumbnail.transform.SetParent(_grid2020.transform);
            newThumbnail.Init(this, i, _grid2020.transform);
            _2020Thumbnails.Add(newThumbnail);
        }

        _grid2020.enabled = false;
    }
}
