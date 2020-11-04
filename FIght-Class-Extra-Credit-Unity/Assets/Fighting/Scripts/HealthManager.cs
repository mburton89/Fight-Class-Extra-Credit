using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public float p1Health;
    public Image p1HealthBar;
    public Image p1Thumbnail;

    public float p2Health;
    public Image p2HealthBar;
    public Image p2Thumbnail;

    private void Awake()
    {
        Instance = this;
        p1Health = 1f;
        p2Health = 1f;
    }

    public void DecreaseP1Health(float amountToDecrease)
    {
        p1Health -= amountToDecrease;
        p1HealthBar.fillAmount = p1Health;

        if (p1Health <= 0)
        {
            KOManager.Instance.ShowWin(false);
        }
    }

    public void DecreaseP2Health(float amountToDecrease)
    {
        p2Health -= amountToDecrease;
        p2HealthBar.fillAmount = p2Health;

        if (p2Health <= 0)
        {
            KOManager.Instance.ShowWin(true);
        }
    }
}
