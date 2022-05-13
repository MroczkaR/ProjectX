using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class StartScript : MonoBehaviour
{
    //public TMPro.TMP_Text kamiennemonety;
    //public TMPro.TMP_Text kamien;

    public TMPro.TMP_Text tStone;
    public TMPro.TMP_Text tWood;
    public TMPro.TMP_Text tOldCoins;

    public static int aktscena = 0;
    void Start()
    {
        if(PlayerPrefs.GetInt("NowaGra") == 0)
        {
            Reset.NowaGra();
        }
        if(PlayerPrefs.GetString("Stone") != "")
        {
            Zasoby.Stone = double.Parse(PlayerPrefs.GetString("Stone"));
        }
        else
        {
            Zasoby.Stone = 10;
        }
        if(PlayerPrefs.GetString("OldCoins") != "")
        {
            Zasoby.OldCoin = int.Parse(PlayerPrefs.GetString("OldCoins"));
        }
        else
        {
            Zasoby.OldCoin = 10;
        }
        if(PlayerPrefs.GetString("Wood") != "")
        {
            Zasoby.Wood = double.Parse(PlayerPrefs.GetString("Wood"));
        }
        else
        {
            Zasoby.Wood = 10;
        }
        Zasoby.CopperOre = PlayerPrefs.GetInt("CopperOre");
        tOldCoins.text = Zasoby.OldCoin.ToString();
        tStone.text = Zasoby.Stone.ToString();
        tWood.text = Zasoby.Wood.ToString();  
        AktualizujCzas();

        if(PlayerPrefs.GetString("Przychod") != "")
        {
            Kopanie.przychod = double.Parse(PlayerPrefs.GetString("Przychod"));
        }
        else
        {
            Kopanie.przychod = 0;
        }
        if(PlayerPrefs.GetString("PrzychodDrewna") != "")
        {
            Tartak.przychodDrewna = double.Parse(PlayerPrefs.GetString("PrzychodDrewna"));
        }
        else
        {
            Tartak.przychodDrewna = 0;
        }
        StartCoroutine(PrzychodStaly());
        

        
                 
    }

    IEnumerator PrzychodStaly()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Zasoby.Stone += Kopanie.przychod;
            Zasoby.Stone = Math.Round(Zasoby.Stone, 2);
            tStone.text = Zasoby.Stone.ToString();
            Zasoby.Wood += Tartak.przychodDrewna;
            Zasoby.Wood = Math.Round(Zasoby.Wood, 2);
            tWood.text = Zasoby.Wood.ToString();
            PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
            PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
            PlayerPrefs.SetString("dzien", System.DateTime.Now.ToString("dd"));
            PlayerPrefs.SetString("godziny", System.DateTime.Now.ToString("HH"));
            PlayerPrefs.SetString("minuty", System.DateTime.Now.ToString("mm"));
            AktualizujCzas();
            
        }
    }

    public void AktualizujCzas()
    {
        Offline.dzien =  PlayerPrefs.GetString("dzien"); 
        Offline.godziny = PlayerPrefs.GetString("godziny");
        Offline.minuty = PlayerPrefs.GetString("minuty");
    }


    public void ZmienNaMiasto()
    {
        SceneManager.LoadScene(1);
        aktscena = 1;
        AktualizujCzas();
        
    }

    public void ZmienNaMenu()
    {
        SceneManager.LoadScene(0);
        aktscena = 0;
        AktualizujCzas();
    }

    public void ZmienNaPostac()
    {
        SceneManager.LoadScene(2);
        aktscena = 2;
        AktualizujCzas();
    }

    public void ZmienNaKopalnie()
    {
        if(PlayerPrefs.GetInt("WybudowanaKopalnia") == 0)
        {
            aktscena = 3;
            Budowanie.nazwabudynku = "Wybudować Kopalnie ?";
            Budowanie.kosztbudowykamien = 4;
            Budowanie.kosztbudowydrzewo = 6;
            Budowanie.openBuildPanel = true;
        }
        else
        {
            SceneManager.LoadScene(3);
            aktscena = 3;
            AktualizujCzas();
        }
        
    }

    public void ZmienNaTartak()
    {
        if(PlayerPrefs.GetInt("WybudowanyTartak") == 0)
        {
            aktscena = 4;
            Budowanie.nazwabudynku = "Wybudować Tartak ?";
            Budowanie.kosztbudowykamien = 6;
            Budowanie.kosztbudowydrzewo = 4;
            Budowanie.openBuildPanel = true;
        }
        else
        {
            SceneManager.LoadScene(4);
            aktscena = 4;
            AktualizujCzas();
        }
        
    }

    public void ZmienNaPolowanie1()

    {
        SceneManager.LoadScene(5);
        aktscena = 5;
        AktualizujCzas();
    }

    public void ZmienNaSklep()

    {
            aktscena = 6;
             SceneManager.LoadScene(6);
             AktualizujCzas();   
    }

    public void ZmienNaEkwipunek()
    {
        SceneManager.LoadScene(7);
        aktscena = 7;
        AktualizujCzas();
    }

    public void ZmienNaWalka()
    {
        if(PlayerPrefs.GetInt("WybudowanyDom") == 2)
        {
            ErrorScript.errortext = "Przed polowaniem, wybuduj sobie dom, aby mieć gdzie opatrywać ciężkie rany";
            ErrorScript.showErrorPanel = true;
        }
        else if(PlayerPrefs.GetInt("Wyleczony") == 1)
        {
            ErrorScript.errortext = "Twoja Postac odpoczywa teraz w domu, przerwij odpoczynek lub poczekaj, aż dojdzie do pełni sił";
            ErrorScript.showErrorPanel = true;
        }
        else if(Dane.akthppost <= 0)
        {
            ErrorScript.errortext = "Twoja Postac jest zbyt ciężko ranna, aby walczyć, udaj się do domu i opatrz rany";
            ErrorScript.showErrorPanel = true;
        }
        else
        {
            SceneManager.LoadScene(8);
            aktscena = 8;
            AktualizujCzas();
        }
        
    }

    public void ZmienNaDom()
    {
        
        if(PlayerPrefs.GetInt("WybudowanyTartak") == 0)
        {
            aktscena = 1;
            ErrorScript.errortext = "Najpierw wybuduj Tartak";
            ErrorScript.showErrorPanel = true;
        }
         else if(PlayerPrefs.GetInt("WybudowanaKopalnia") == 0)
        {
            aktscena = 1;
            ErrorScript.errortext = "Najpierw wybuduj Kopalnie";
            ErrorScript.showErrorPanel = true;
        }
        else if(PlayerPrefs.GetInt("WybudowanyDom") == 0)
        {
            aktscena = 11;
            Budowanie.nazwabudynku = "Wybudować Dom ?";
            Budowanie.kosztbudowykamien = 5;
            Budowanie.kosztbudowydrzewo = 10;
            Budowanie.openBuildPanel = true;
        }
        else
        {  
             SceneManager.LoadScene(11);
             aktscena = 11;
             AktualizujCzas();

        }

           
        
        
    }

    public void ZmienNaAdminPanel()
    {
        SceneManager.LoadScene(12);
        aktscena = 12;
        AktualizujCzas();
    }

    public void ZmienNaHute()
    {
        if(PlayerPrefs.GetInt("WybudowanaHuta") == 0)
        {
            if(PlayerPrefs.GetInt("WybudowanaKopalnia") == 0)
            {
                aktscena = 1;
                ErrorScript.errortext = "Najpierw wybuduj Kopalnie";
                ErrorScript.showErrorPanel = true;
            }
            else if(PlayerPrefs.GetInt("WybudowanyTartak") == 0)
            {
                 aktscena = 1;
                ErrorScript.errortext = "Najpierw wybuduj Tartak";
                ErrorScript.showErrorPanel = true;
            }
            else
            {
                aktscena = 13;
                Budowanie.nazwabudynku = "Wybudować Hutę ?";
                Budowanie.kosztbudowykamien = 25;
                Budowanie.kosztbudowydrzewo = 15;
                Budowanie.openBuildPanel = true;
            }
            
        }
        else
        {
            SceneManager.LoadScene(13);
            aktscena = 13;
            AktualizujCzas();
        }
        
    }
  
        public void Quit()
    {
        Application.Quit();
    }
}
