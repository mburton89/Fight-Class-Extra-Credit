using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            HealthManager.Instance.DecreaseP1Health(.1f);
        }
    }
}
