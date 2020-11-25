using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeYearButton : MonoBehaviour
{
    public CharacterSelectMenu menu;

    public bool nextYear;

    public static int yearIndex = 0;
    private int maxYearIndex = 1;

    public void SwitchYear()
    {
        if (nextYear)
        {
            if (yearIndex != maxYearIndex)
            {
                yearIndex++;
            }
            else
            {
                yearIndex = 0;
            }
        }
        else
        {
            if (yearIndex != 0)
            {
                yearIndex--;
            }
            else
            {
                yearIndex = maxYearIndex;
            }
        }

        menu.SwitchYear(yearIndex);
    }
}
