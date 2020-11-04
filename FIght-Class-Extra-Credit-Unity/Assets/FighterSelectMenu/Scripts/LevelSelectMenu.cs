using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] private SelectableLevel _selectableLevelPrefab;
    [SerializeField] private GridLayoutGroup _grid;

    private List<SelectableLevel> _allLevels = new List<SelectableLevel>();

    [SerializeField] private LevelGridNavigator _levelNavigator;

    void Start()
    {
        for (int i = 0; i < DataReferenceManager.Instance.levelImages.Count; i++)
        {
            SelectableLevel newSelectableLevel = Instantiate(_selectableLevelPrefab);
            newSelectableLevel.transform.SetParent(_grid.transform);
            newSelectableLevel.Init(i, _grid.transform);
            _allLevels.Add(newSelectableLevel);
        }

        _allLevels[0].Select();

        _levelNavigator.Init(_allLevels);
    }
}
