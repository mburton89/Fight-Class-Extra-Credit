using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private Button _overlayButton;

    void Awake()
    {
        _overlayButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _overlayButton.onClick.AddListener(HomeNavigator.Instance.CloseOptionsMenu);        
    }

    private void OnDisable()
    {
        _overlayButton.onClick.RemoveListener(HomeNavigator.Instance.CloseOptionsMenu);
    }
}
