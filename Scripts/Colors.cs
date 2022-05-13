using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    public static int SkillColor;
    public static Color32 ActualColor;
    public static Color32 WoodBronze = new Color32(173, 110, 53, 255);
    public static Color32 WoodHelmet = new Color32(113, 61, 36, 255);
    public static Color32 BrownShoes = new Color32(239, 105, 42, 255);
    public static Color32 Black = new Color32(0, 0, 0, 255);
    public static Color32 White = new Color32(255, 255, 255, 255);


    public static void CheckColor(int Index)
    {
        if(Index == 101 || Index == 0)
        {
            ActualColor = WoodBronze;
        }
        else if(Index == 201 || Index == 1 || Index == 301)
        {
            ActualColor = WoodHelmet;
        }
        else if(Index == 401 || Index == 0)
        {
            ActualColor = BrownShoes;
        }
    }
    public static void CheckSkillColor(int Index)
    {
        if(Index == -1)
        {
            ActualColor = Black;
        }
        else
        {
            ActualColor = White;
        }
    }
}
