using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Chances : MonoBehaviour
{
    
    public GameObject ChancesPanel;
    public TMPro.TMP_Text CopperOreChanceT;
    public static int SzansaCopperOre = 100000;
    public static int SzansaIronOre = 0;
    public static bool ZmianaSzansy = true;
    int panelOn = 0;
    static int pozKopalni;

    public static void CheckChances()
    {
        pozKopalni = int.Parse(PlayerPrefs.GetString("PoziomKopalni"));
        if(pozKopalni < 5)
        {
            SzansaCopperOre = 100000;
        }
        else if(pozKopalni < 10)
        {
            SzansaCopperOre = 50000;
        }
        else if(pozKopalni < 12)
        {
            SzansaCopperOre = 20000;
        }
        else if(pozKopalni < 14)
        {
            SzansaCopperOre = 10000;
        }
        else if(pozKopalni < 16)
        {
            SzansaCopperOre = 5000;
        }
        else if(pozKopalni < 18)
        {
            SzansaCopperOre = 2000;
        }
        else if(pozKopalni < 20)
        {
            SzansaCopperOre = 1000;
        }
        else if(pozKopalni < 22)
        {
            SzansaCopperOre = 500;
            SzansaIronOre = 10000;
        }
        else if(pozKopalni < 24)
        {
            SzansaCopperOre = 400;
        }
        else if(pozKopalni < 26)
        {
            SzansaCopperOre = 300;
        }
        else if(pozKopalni < 28)
        {
            SzansaCopperOre = 250;
        }
        else if(pozKopalni < 30)
        {
            SzansaCopperOre = 200;
            SzansaIronOre = 5000;
        }
        else if(pozKopalni < 32)
        {
            SzansaCopperOre = 150;
        }
        else if(pozKopalni < 34)
        {
            SzansaCopperOre = 125; 
        }
        else if(pozKopalni < 36)
        {
            SzansaCopperOre = 100;
        }
        else
        {
            SzansaCopperOre = 50;
            SzansaIronOre = 1000;
        }

        ZmianaSzansy = true;
        PlayerPrefs.SetInt("SzansaCopperOre", SzansaCopperOre);
    }


    public void ChancePanel()
    {
        if(panelOn == 0)
        {
            ChancesPanel.SetActive(true);
            panelOn = 1;
        }
        else
        {
            ChancesPanel.SetActive(false);
            panelOn = 0; 
        }
    }

    void Update()
    {
        if(ZmianaSzansy == true)
        {
            float x =  ((1f / Kopanie.SzansaCopper) * 100);
            double y = (double)x;
            y = Math.Round(y, 6);
            CopperOreChanceT.text = (y.ToString() + " %");
            ZmianaSzansy = false;
        }
    }

}
