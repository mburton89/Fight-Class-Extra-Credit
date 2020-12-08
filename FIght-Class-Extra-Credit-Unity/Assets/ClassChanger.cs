using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClassChanger : MonoBehaviour
{
    public ChangeYearButton year;

    [SerializeField] private TextMeshProUGUI _class2019;
    [SerializeField] private TextMeshProUGUI _class2020;

    private bool is2019;

    public void Start()
    {
        if (year.nextYear)
        {
            
        }
    }
}
