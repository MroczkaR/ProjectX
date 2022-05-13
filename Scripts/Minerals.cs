using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Minerals : MonoBehaviour
{
    public GameObject MineralPanel;
    public TMPro.TMP_Text rudaMiedziT;
    public TMPro.TMP_Text rudaZelazaT;
    public static bool zmienMineraly = true;

    int mineralpanelon = 0;

    public void MineralsPanel()
    {
        if(mineralpanelon == 1)
        {
            MineralPanel.SetActive(false);
            mineralpanelon = 0;
        }
        else
        {
            MineralPanel.SetActive(true);
            mineralpanelon = 1;
        } 
    }

    private void Update()
    {
        if(zmienMineraly == true)
        {
            rudaMiedziT.text = Zasoby.CopperOre.ToString();
            zmienMineraly = false;
        }
        
    }
}
