using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectMenu : MonoBehaviour
{

    public int currentYear = 0; 

    [SerializeField] private SelectableThumbnail _selectableThumbnailPrefab;
    [SerializeField] private GridLayoutGroup _grid2019;
    [SerializeField] private GridLayoutGroup _grid2020;

    private List<SelectableThumbnail> _2019Thumbnails = new List<SelectableThumbnail>();
    private List<SelectableThumbnail> _2020Thumbnails = new List<SelectableThumbnail>();

    [SerializeField] private CharacterGridNavigator _player1Navigator;
    [SerializeField] private CharacterGridNavigator _player2Navigator;

    [SerializeField] private TextMeshProUGUI _classYearDisplay;

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
        
        if (!FighterSelectSceneController.Instance.player1Selected)
        {
            _player1Navigator.Deselect();
        }
        else
        {
            _player1Navigator.Deselect();
            _player2Navigator.Deselect();
        }
        

        if (index == 0) // Year 2019
        {
            //_2020Thumbnails[0].Select(!FighterSelectSceneController.Instance.player1Selected);
            _2019Thumbnails[0].Select(!FighterSelectSceneController.Instance.player1Selected);
            //_2019Thumbnails[0].Select(false);

            _player1Navigator.Init(_2019Thumbnails);
            _player2Navigator.Init(_2019Thumbnails);

            _grid2020.gameObject.SetActive(false);
            _grid2019.gameObject.SetActive(true);

            _classYearDisplay.SetText("Class of\n2019");
        }
        else if (index == 1) // Year 2020
        {
            //_2019Thumbnails[0].Select(!FighterSelectSceneController.Instance.player1Selected);
            _2020Thumbnails[0].Select(!FighterSelectSceneController.Instance.player1Selected);
            //_2020Thumbnails[0].Select(false);

            _player1Navigator.Init(_2020Thumbnails);
            _player2Navigator.Init(_2020Thumbnails);

            _grid2019.gameObject.SetActive(false);
            _grid2020.gameObject.SetActive(true);

            _classYearDisplay.SetText("Class of\n2020");
        }
        currentYear = index; 
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

        _grid2019.gameObject.SetActive(false);

    }

    private void Initialize2020()
    {
        Debug.Log(DataReferenceManager.Instance.characterNames.Count);
        for (int i = 9; i < DataReferenceManager.Instance.characterNames.Count; i++)
        {
            SelectableThumbnail newThumbnail = Instantiate(_selectableThumbnailPrefab);
            newThumbnail.transform.SetParent(_grid2020.transform);
            newThumbnail.Init(this, i, _grid2020.transform);

            _2020Thumbnails.Add(newThumbnail);
        }

        _grid2020.gameObject.SetActive(false);
    }
}
