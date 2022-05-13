using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Tartak : MonoBehaviour
{
    public TMPro.TMP_Text tWood;
    public TMPro.TMP_Text tStone;
    public TMPro.TMP_Text tOldCoins;
   public GameObject InfoTartakPanel;
   public TMPro.TMP_Text poziomTartakuT;
   public TMPro.TMP_Text siekanieT;
   public TMPro.TMP_Text wydajnoscPracTartakuT;
   public TMPro.TMP_Text iloscPracTartakuT;
   public TMPro.TMP_Text maxPracTartakuT;
   public TMPro.TMP_Text przychodDrewnat;
   //public TMPro.TMP_Text zebranot;
   public TMPro.TMP_Text kosztRobotnikaTartakuT;
   public TMPro.TMP_Text kosztUlepszeniaTartakuT;
   public TMPro.TMP_Text kosztUlepszeniaTartakuDrewnoT;
   static int poziomTartaku = 0;
   static double siekanie = 0;
   static double wydajnoscPracTartaku = 0;
   static int maxPracTartaku = 0;
   public static double przychodDrewna = 0;
  // public static double zebrano = 0;
   static int cenaUlepTartakuKam = 6;
   static int cenaUlepTartakuDrewno = 4;
   static int iloscPracTartaku = 0;
   static int cenaPracTartaku = 1;
    private void Start()
    {
        //StartCoroutine(PrzychodStaly());
        if(PlayerPrefs.GetString("PoziomTartaku") != "")
        {
            poziomTartaku = int.Parse(PlayerPrefs.GetString("PoziomTartaku"));
            siekanie = double.Parse(PlayerPrefs.GetString("Siekanie"));
            Zasoby.Stone = double.Parse(PlayerPrefs.GetString("Stone"));
            Zasoby.Wood = double.Parse(PlayerPrefs.GetString("Wood"));
            wydajnoscPracTartaku = double.Parse(PlayerPrefs.GetString("WydajnoscPracTartaku"));
            maxPracTartaku = int.Parse(PlayerPrefs.GetString("MaxPracTartaku"));
            cenaUlepTartakuKam = int.Parse(PlayerPrefs.GetString("CenaUlepTartakuKam"));
            cenaUlepTartakuDrewno = int.Parse(PlayerPrefs.GetString("CenaUlepTartakuDrewno"));
            if(PlayerPrefs.GetString("IloscPracTartaku") != "")
            {
                iloscPracTartaku = int.Parse(PlayerPrefs.GetString("IloscPracTartaku"));
                cenaPracTartaku = int.Parse(PlayerPrefs.GetString("CenaPracTartaku"));
                przychodDrewna = double.Parse(PlayerPrefs.GetString("PrzychodDrewna"));
                Zasoby.OldCoin = int.Parse(PlayerPrefs.GetString("OldCoins"));
               // zebrano = double.Parse(PlayerPrefs.GetString("Zebrano"));
            }      
        }
        else
        {
            UlepszTartak();
        }
                        
            poziomTartakuT.text = poziomTartaku.ToString();
            siekanieT.text = siekanie.ToString();
            wydajnoscPracTartakuT.text = wydajnoscPracTartaku.ToString();
            iloscPracTartakuT.text = iloscPracTartaku.ToString();
            maxPracTartakuT.text = maxPracTartaku.ToString();
            przychodDrewnat.text = przychodDrewna.ToString();
            kosztUlepszeniaTartakuT.text = cenaUlepTartakuKam.ToString();
            kosztUlepszeniaTartakuDrewnoT.text = cenaUlepTartakuDrewno.ToString();
            kosztRobotnikaTartakuT.text = cenaPracTartaku.ToString();
    }

    void CenaPracPlus()
    {
        if(poziomTartaku < 6)
        {
            wydajnoscPracTartaku += 0.01;
            if(poziomTartaku % 2 == 1)
        {
            maxPracTartaku += 1;
        } 
        }
        else if(poziomTartaku < 15)
        {
            wydajnoscPracTartaku += 0.02;
            if(poziomTartaku % 3 == 2)
            {
                maxPracTartaku ++;
            }
        }
        else if(poziomTartaku < 31)
        {
            wydajnoscPracTartaku += 0.04;
            if(poziomTartaku % 4 == 2)
            {
                maxPracTartaku ++;
            }
        }
        else
        {
            wydajnoscPracTartaku += 0.06;
            if(poziomTartaku % 5 == 0)
            {
                maxPracTartaku ++;
            }
        }
    }

    void CenaTartakuPlus()
    {
        if(poziomTartaku < 10)
        {
            cenaUlepTartakuKam = cenaUlepTartakuKam * 3/2;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno *3/2;
        }
        else if(poziomTartaku < 30)
        {
            cenaUlepTartakuKam = cenaUlepTartakuKam * 6/5;
            cenaUlepTartakuKam = cenaUlepTartakuKam / 5;
            cenaUlepTartakuKam = cenaUlepTartakuKam * 5;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno *6/5;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno /5;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno *5;
        }
        else
        {
            cenaUlepTartakuKam = cenaUlepTartakuKam * 11/10;
            cenaUlepTartakuKam = cenaUlepTartakuKam / 10;
            cenaUlepTartakuKam = cenaUlepTartakuKam * 10;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno *11/10;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno /10;
            cenaUlepTartakuDrewno = cenaUlepTartakuDrewno *10;
        }
    }

    void WzmocnienieSiekania()
    {
        if(poziomTartaku < 2)
        {
            siekanie += 0.1;
        }
        else if(poziomTartaku < 4)
        {
            siekanie += 0.05;
        }
        else if(poziomTartaku < 7)
        {
            siekanie += 0.1;
        }
        else if(poziomTartaku < 11)
        {
            siekanie += 0.15;
        }
        else if(poziomTartaku < 16)
        {
            siekanie += 0.2;
        }
        else if(poziomTartaku < 26)
        {
            siekanie = siekanie * 115/100;
            siekanie = siekanie * 10;
            siekanie = siekanie - (siekanie % 1);
            siekanie = siekanie / 10;
        }
        else
        {
            siekanie = siekanie * 105/100;
            siekanie = siekanie * 10;
            siekanie = siekanie - (siekanie % 1);
            siekanie = siekanie / 10;
        }

    }
       public void Siekiera()
   {

       Zasoby.Wood += siekanie;
       Zasoby.Wood = Math.Round(Zasoby.Wood, 2);
       tWood.text = Zasoby.Wood.ToString();
       PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
   }


    public void UlepszTartak()
    {
        if(Dane.poziompost >= 0)
        {
        if(Zasoby.Stone >= cenaUlepTartakuKam)
        {
            if(Zasoby.Wood >= cenaUlepTartakuDrewno)
        {
        poziomTartaku ++;
        poziomTartakuT.text = poziomTartaku.ToString();
        Zasoby.Stone -= cenaUlepTartakuKam;
        Zasoby.Stone = Math.Round(Zasoby.Stone, 2);
        Zasoby.Wood -= cenaUlepTartakuDrewno;
        Zasoby.Wood = Math.Round(Zasoby.Wood, 2);
        WzmocnienieSiekania();
        CenaPracPlus();
        CenaTartakuPlus();
        siekanieT.text = siekanie.ToString(); 
        tStone.text = Zasoby.Stone.ToString();
        tWood.text = Zasoby.Wood.ToString();
        wydajnoscPracTartakuT.text = wydajnoscPracTartaku.ToString();
        maxPracTartakuT.text = maxPracTartaku.ToString();
        przychodDrewna = iloscPracTartaku * wydajnoscPracTartaku;
        przychodDrewnat.text = przychodDrewna.ToString(); 
        kosztUlepszeniaTartakuT.text = cenaUlepTartakuKam.ToString();
        kosztUlepszeniaTartakuDrewnoT.text = cenaUlepTartakuDrewno.ToString();
        PlayerPrefs.SetString("PoziomTartaku", poziomTartaku.ToString());
        PlayerPrefs.SetString("Siekanie", siekanie.ToString());
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
        PlayerPrefs.SetString("WydajnoscPracTartaku", wydajnoscPracTartaku.ToString());
        PlayerPrefs.SetString("MaxPracTartaku", maxPracTartaku.ToString());
        PlayerPrefs.SetString("CenaUlepTartakuKam", cenaUlepTartakuKam.ToString());
        PlayerPrefs.SetString("CenaUlepTartakuDrewno", cenaUlepTartakuDrewno.ToString());
        PlayerPrefs.SetString("PrzychodDrewna", przychodDrewna.ToString());
        }
        else
        {
            ErrorScript.errortext = "Nie wystarczająca ilość drewna !";
            ErrorScript.showErrorPanel = true;
        }
        }
        else
        {
            ErrorScript.errortext = "Nie wystarczająca ilość kamienia !";
            ErrorScript.showErrorPanel = true;
        }
        }
        else
        {
            ErrorScript.errortext = "Masz za niski poziom postaci !";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void DodajPracownika()
    {
        if(maxPracTartaku > iloscPracTartaku)
        {
            if(Zasoby.OldCoin >= cenaPracTartaku)
            {
                iloscPracTartaku ++;
                przychodDrewna = iloscPracTartaku * wydajnoscPracTartaku;
                Zasoby.OldCoin -= cenaPracTartaku;
                cenaPracTartaku = cenaPracTartaku + 1;
                tOldCoins.text = Zasoby.OldCoin.ToString();
                kosztRobotnikaTartakuT.text = cenaPracTartaku.ToString();
                przychodDrewnat.text = przychodDrewna.ToString();
                iloscPracTartakuT.text = iloscPracTartaku.ToString();
                PlayerPrefs.SetString("IloscPracTartaku", iloscPracTartaku.ToString());
                PlayerPrefs.SetString("PrzychodDrewna", przychodDrewna.ToString());
                PlayerPrefs.SetString("CenaPracTartaku", cenaPracTartaku.ToString());
                PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            }
            else
            {
                ErrorScript.errortext = "Brak monety, aby przypisać pracownika !";
                ErrorScript.showErrorPanel = true;
            }

        }
        else
        {
            ErrorScript.errortext = "Nie możesz przypisać więcej pracowników !";
            ErrorScript.showErrorPanel = true;
        }
    }


   /* IEnumerator PrzychodStaly()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
           // zebranot.text = zebrano.ToString();
        }
    }

   /* public void Zbierz()
    {
        stone += zebrano;
        stones.text = stone.ToString();
        zebrano = 0;
        zebranot.text = zebrano.ToString();
        stone = Math.Round(stone, 2);
        PlayerPrefs.SetString("Zebrano", zebrano.ToString());
        PlayerPrefs.SetString("Stone", stone.ToString());
    }*/

    public void OpenInfoTartak()
    {
        InfoTartakPanel.SetActive(true);
    }

    public void CloseInfoTartak()
    {
        InfoTartakPanel.SetActive(false);
    }
}

