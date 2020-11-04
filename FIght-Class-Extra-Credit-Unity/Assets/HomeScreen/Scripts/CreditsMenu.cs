using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    private Button _overlayButton;

    void Awake()
    {
        _overlayButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _overlayButton.onClick.AddListener(HomeNavigator.Instance.CloseCreditsMenu);        
    }

    private void OnDisable()
    {
        _overlayButton.onClick.RemoveListener(HomeNavigator.Instance.CloseCreditsMenu);
    }
}
