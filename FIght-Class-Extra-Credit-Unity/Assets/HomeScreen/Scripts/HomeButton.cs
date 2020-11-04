using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    public enum Type { Start, Credits, Options };

    public Type type;
    public float blinkDuration;

    [SerializeField] private Image _outline;
    [SerializeField] private Button _button;

    private void Start()
    {
        StartCoroutine(blink());
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleClick);
    }

    public void HandleSelect()
    {
        if (type == Type.Start)
        {
            HomeNavigator.Instance.GoToCharacterSelect();
        }
        else if (type == Type.Credits)
        {
            HomeNavigator.Instance.OpenCreditsMenu();
        }
        else if (type == Type.Options)
        {
            HomeNavigator.Instance.OpenOptionsMenu();
        }
        else
        {
            Debug.LogWarning("TYPE NOT SET");
        }
    }

    private void HandleClick()
    {
        HandleSelect();
        HomeNavigator.Instance.MarkButtonSelected(this);
    }

    public void Select()
    {
        _outline.enabled = true;
    }

    public void Deselect()
    {
        _outline.enabled = false;
    }

    private IEnumerator blink()
    {
        _outline.color = Color.grey;
        yield return new WaitForSeconds(blinkDuration);
        _outline.color = Color.white;
        yield return new WaitForSeconds(blinkDuration);
        StartCoroutine(blink());
    }
}
