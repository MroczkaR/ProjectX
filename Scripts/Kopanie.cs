using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Kopanie : MonoBehaviour
{
   public GameObject InfoKopalniaPanel;
   public TMPro.TMP_Text stonecoins;
   public TMPro.TMP_Text stones;
   public TMPro.TMP_Text woods;
   public TMPro.TMP_Text poziomkopalnit;
   public TMPro.TMP_Text kopaniet;
   public TMPro.TMP_Text wydajnoscpract;
   public TMPro.TMP_Text iloscpract;
   public TMPro.TMP_Text maxpract;
   public TMPro.TMP_Text przychodt;
   //public TMPro.TMP_Text zebranot;
   public TMPro.TMP_Text kosztrobotnika;
   public TMPro.TMP_Text kosztulepszenia;
   public TMPro.TMP_Text kosztUlepszeniaDrewno;
   public TMPro.TMP_Text comboT;
   public TMPro.TMP_Text checkingcombo;
   public TMPro.TMP_Text wylosowana;
   static int poziomkopalni = 0;
   static double kopanie = 0;
   static double wydajnoscprac = 0;
   static int maxprac = 0;
   public static double przychod = 0;
  // public static double zebrano = 0;
   static int cenaulepszenia = 4;
   static int cenaulepszeniadrewno = 6;
   static int iloscprac = 0;
   static int cenapracownika = 1;
    public static int SzansaCopper = 100000;
    int losowanieCopper;
    double combo = 1;
    int liczcombo = 0;

    private void Start()
    {
        //StartCoroutine(PrzychodStaly());
        if(PlayerPrefs.GetString("PoziomKopalni") != "")
        {
            poziomkopalni = int.Parse(PlayerPrefs.GetString("PoziomKopalni"));
            kopanie = double.Parse(PlayerPrefs.GetString("Kopanie"));
            Zasoby.Stone = double.Parse(PlayerPrefs.GetString("Stone"));
            Zasoby.Wood = double.Parse(PlayerPrefs.GetString("Wood"));
            wydajnoscprac = double.Parse(PlayerPrefs.GetString("Wydajnoscprac"));
            maxprac = int.Parse(PlayerPrefs.GetString("MaxPrac"));
            cenaulepszenia = int.Parse(PlayerPrefs.GetString("CenaUlepKopalniKam"));
            cenaulepszeniadrewno = int.Parse(PlayerPrefs.GetString("CenaUlepKopalniDrewno"));
            if(PlayerPrefs.GetString("IloscPrac") != "")
            {
                iloscprac = int.Parse(PlayerPrefs.GetString("IloscPrac"));
                cenapracownika = int.Parse(PlayerPrefs.GetString("CenaPrac"));
                przychod = double.Parse(PlayerPrefs.GetString("Przychod"));
                Zasoby.OldCoin = int.Parse(PlayerPrefs.GetString("OldCoins"));
            }      
        }
        else
        {
            UlepszKopalnie();
        }
                   
            poziomkopalnit.text = poziomkopalni.ToString();
            kopaniet.text = kopanie.ToString();
            wydajnoscpract.text = wydajnoscprac.ToString();
            iloscpract.text = iloscprac.ToString();
            maxpract.text = maxprac.ToString();
            przychodt.text = przychod.ToString();
            kosztulepszenia.text = cenaulepszenia.ToString();
            kosztrobotnika.text = cenapracownika.ToString();
            kosztUlepszeniaDrewno.text = cenaulepszeniadrewno.ToString();
            Chances.CheckChances();
            Chances.ZmianaSzansy = true;


    }

    void CenaPracPlus()
    {
        if(poziomkopalni < 6)
        {
            wydajnoscprac += 0.01;
            if(poziomkopalni % 3 == 1)
        {
            maxprac += 1;
        } 
        }
        else if(poziomkopalni < 15)
        {
            wydajnoscprac += 0.02;
            if(poziomkopalni % 4 == 2)
            {
                maxprac ++;
            }
        }
        else if(poziomkopalni < 31)
        {
            wydajnoscprac += 0.03;
            if(poziomkopalni % 5 == 2)
            {
                maxprac ++;
            }
        }
        else
        {
            wydajnoscprac += 0.05;
            if(poziomkopalni % 6 == 0)
            {
                maxprac ++;
            }
        }
    }

    void CenaKopalniPlus()
    {
        if(poziomkopalni < 10)
        {
            cenaulepszenia = cenaulepszenia * 3/2;
            cenaulepszeniadrewno = cenaulepszeniadrewno * 3/2;
        }
        else if(poziomkopalni < 30)
        {
            cenaulepszenia = cenaulepszenia * 6/5;
            cenaulepszenia = cenaulepszenia / 5;
            cenaulepszenia = cenaulepszenia * 5;
            cenaulepszeniadrewno = cenaulepszeniadrewno * 6/5;
            cenaulepszeniadrewno = cenaulepszeniadrewno / 5;
            cenaulepszeniadrewno = cenaulepszeniadrewno * 5;
        }
        else
        {
            cenaulepszenia = cenaulepszenia * 11/10;
            cenaulepszenia = cenaulepszenia / 10;
            cenaulepszenia = cenaulepszenia * 10;
            cenaulepszeniadrewno = cenaulepszeniadrewno * 11/10;
            cenaulepszeniadrewno = cenaulepszeniadrewno / 10;
            cenaulepszeniadrewno = cenaulepszeniadrewno * 10;
        }

    }

    void WzmocnienieKopania()
    {
        if(poziomkopalni < 2)
        {
            kopanie += 0.1;
        }
        else if(poziomkopalni < 4)
        {
            kopanie += 0.05;
        }
        else if(poziomkopalni < 7)
        {
            kopanie += 0.1;
        }
        else if(poziomkopalni < 11)
        {
            kopanie += 0.15;
        }
        else if(poziomkopalni < 16)
        {
            kopanie += 0.2;
        }
        else if(poziomkopalni < 21)
        {
            kopanie += 0.3;
        }
        else if(poziomkopalni < 26)
        {
            kopanie = kopanie * 115/100;
            kopanie = kopanie * 10;
            kopanie = kopanie - (kopanie % 1);
            kopanie = kopanie / 10;
        }
        else
        {
            kopanie = kopanie * 105/100;
            kopanie = kopanie * 10;
            kopanie = kopanie - (kopanie % 1);
            kopanie = kopanie / 10;
        }

    }
    public void Kop()
    {
        Zasoby.Stone += kopanie;
        Zasoby.Stone = Math.Round(Zasoby.Stone, 2);
        stones.text = Zasoby.Stone.ToString();
        SzansaCopper = (int)(Chances.SzansaCopperOre / combo);
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        losowanieCopper = UnityEngine.Random.Range(0, SzansaCopper + 1);
        wylosowana.text = losowanieCopper.ToString();
        if(losowanieCopper == SzansaCopper / 2)
        {
            Zasoby.CopperOre += 1;
            PlayerPrefs.SetInt("CopperOre", Zasoby.CopperOre);
            Minerals.zmienMineraly = true;
        }
        liczcombo ++;
        if(liczcombo >= 2)
        {
            combo += 0.01;
            combo = Math.Round(combo, 2);
            liczcombo = 0;
            SzansaCopper = (int)(Chances.SzansaCopperOre / combo);
            checkingcombo.text = SzansaCopper.ToString();
            Chances.ZmianaSzansy = true;
            comboT.text = combo.ToString();
        }
    }


    public void UlepszKopalnie()
    {
        if(Dane.poziompost >= 0)
        {
        if(Zasoby.Stone >= cenaulepszenia)
        {
            if(Zasoby.Wood >= cenaulepszeniadrewno)
        {
        poziomkopalni ++;
        poziomkopalnit.text = poziomkopalni.ToString();
        Zasoby.Stone -= cenaulepszenia;
        Zasoby.Stone = Math.Round(Zasoby.Stone, 2);
        Zasoby.Wood -= cenaulepszeniadrewno;
        Zasoby.Wood = Math.Round(Zasoby.Wood, 2);
        WzmocnienieKopania();
        CenaPracPlus();
        CenaKopalniPlus();
        kopaniet.text = kopanie.ToString(); 
        stones.text = Zasoby.Stone.ToString();
        woods.text = Zasoby.Wood.ToString();
        wydajnoscpract.text = wydajnoscprac.ToString();
        maxpract.text = maxprac.ToString();
        przychod = iloscprac * wydajnoscprac;
        przychodt.text = przychod.ToString(); 
        kosztulepszenia.text = cenaulepszenia.ToString();
        kosztUlepszeniaDrewno.text = cenaulepszeniadrewno.ToString();
        PlayerPrefs.SetString("PoziomKopalni", poziomkopalni.ToString());
        PlayerPrefs.SetString("Kopanie", kopanie.ToString());
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
        PlayerPrefs.SetString("Wydajnoscprac", wydajnoscprac.ToString());
        PlayerPrefs.SetString("MaxPrac", maxprac.ToString());
        PlayerPrefs.SetString("CenaUlepKopalniKam", cenaulepszenia.ToString());
        PlayerPrefs.SetString("CenaUlepKopalniDrewno", cenaulepszeniadrewno.ToString());
        PlayerPrefs.SetString("Przychod", przychod.ToString());
        Chances.ZmianaSzansy = true;
        Chances.CheckChances();
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
        if(maxprac > iloscprac)
        {
            if(Zasoby.OldCoin >= cenapracownika)
            {
                iloscprac ++;
                przychod = iloscprac * wydajnoscprac;
                Zasoby.OldCoin -= cenapracownika;
                cenapracownika = cenapracownika + 1;
                stonecoins.text = Zasoby.OldCoin.ToString();
                kosztrobotnika.text = cenapracownika.ToString();
                przychodt.text = przychod.ToString();
                iloscpract.text = iloscprac.ToString();
                PlayerPrefs.SetString("IloscPrac", iloscprac.ToString());
                PlayerPrefs.SetString("Przychod", przychod.ToString());
                PlayerPrefs.SetString("CenaPrac", cenapracownika.ToString());
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

    public void OpenInfoKopalnia()
    {
        InfoKopalniaPanel.SetActive(true);
    }

    public void CloseInfoKopalnia()
    {
        InfoKopalniaPanel.SetActive(false);
    }
}

