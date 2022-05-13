using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Reset : MonoBehaviour
{
    public void ResetGry()
    {
        PlayerPrefs.SetInt("NowaGra", 1);
        PlayerPrefs.SetString("PoziomKopalni", "");
        PlayerPrefs.SetString("PoziomTartaku", "");
        PlayerPrefs.SetString("Stone", "10");
        PlayerPrefs.SetString("OldCoins", "10");
        PlayerPrefs.SetString("Wood", "10");
        PlayerPrefs.SetString("Zebrano", "");
        PlayerPrefs.SetString("CenaPrac", "1");
        PlayerPrefs.SetString("IloscPracTartaku", "");
        PlayerPrefs.SetString("IloscPrac", "");
        PlayerPrefs.SetString("Przychod", "");
        PlayerPrefs.SetString("PrzychodDrewna", "");
        PlayerPrefs.SetInt("CopperOre", 0);
        PlayerPrefs.SetInt("PoziomPostaci", 0);
        PlayerPrefs.SetInt("ObronaPostaci", 0);
        PlayerPrefs.SetInt("WitalnoscPostaci", 0);
        PlayerPrefs.SetInt("SilaPostaci", 0);
        PlayerPrefs.SetInt("MocPostaci", 0);
        PlayerPrefs.SetInt("UnikPostaci", 0);
        PlayerPrefs.SetInt("SzczesciePostaci", 0);
        PlayerPrefs.SetInt("AktHpPostaci", 5);
        PlayerPrefs.SetInt("MaxHpPostaci", 5);
        PlayerPrefs.SetInt("MinExpPostaci", 0);
        PlayerPrefs.SetInt("MaxExpPostaci", 1);
        PlayerPrefs.SetInt("MinObrPostaci", 0);
        PlayerPrefs.SetInt("MaxObrPostaci", 1);
        PlayerPrefs.SetInt("KosztStatystyk", 1);
        PlayerPrefs.SetInt("Przetapiane", 0);
        PlayerPrefs.SetInt("Przetopione", 0);
        PlayerPrefs.SetInt("WybudowanaKopalnia", 0);
        PlayerPrefs.SetInt("WybudowanyTartak", 0);
        PlayerPrefs.SetInt("WybudowanyDom", 0);
        PlayerPrefs.SetInt("WybudowanaHuta", 0);
        PlayerPrefs.SetInt("Walczone", 0);
        PlayerPrefs.SetInt("Wyleczony", 2);
        PlayerPrefs.SetInt("SzansaNaUnik", 0);
        PlayerPrefs.SetInt("SzansaNaKryt", 0);
        PlayerPrefs.SetInt("PktMocy", 0);
        PlayerPrefs.SetString("SumaOffline", "");
        PlayerPrefs.SetString("SumaOfflineDrewno", "");
        PlayerPrefs.SetInt("WagaEq", 0);
        PlayerPrefs.SetInt("MaxWagaEq", 10);
        PlayerPrefs.SetInt("Bron", 0);
        PlayerPrefs.SetInt("Zbroja", 0);
        PlayerPrefs.SetInt("Helmet", 0);
        PlayerPrefs.SetInt("Tarcza" , 0);
        PlayerPrefs.SetInt("Buty" , 0);
        PlayerPrefs.SetInt("ShopSlot1", 1);
        PlayerPrefs.SetInt("ShopSlot2", 101);
        PlayerPrefs.SetInt("ShopSlot3", 401);
        PlayerPrefs.SetInt("ShopSlot4", 301);
        for(int i = 5; i<13; i++)
        {
            PlayerPrefs.SetInt("ShopSlot" + i.ToString(), -1);
        }
        for(int i=1; i<11; i++)
        {
            PlayerPrefs.SetInt("EqSlot" + i.ToString(), 0);
        }
        for(int i = 1; i<6; i++)
        {
            PlayerPrefs.SetInt("SqSlot" + i.ToString(), 0);
        }
        for(int i =1; i<10; i++)
        {
            PlayerPrefs.SetInt("SkillLevel" + i.ToString(), 0);
        }


    }

    public static void NowaGra()
    {
        PlayerPrefs.SetInt("NowaGra", 1);
        PlayerPrefs.SetString("PoziomKopalni", "");
        PlayerPrefs.SetString("PoziomTartaku", "");
        PlayerPrefs.SetString("Stone", "10");
        PlayerPrefs.SetString("OldCoins", "10");
        PlayerPrefs.SetString("Wood", "10");
        PlayerPrefs.SetString("Zebrano", "");
        PlayerPrefs.SetString("CenaPrac", "1");
        PlayerPrefs.SetString("IloscPracTartaku", "");
        PlayerPrefs.SetString("IloscPrac", "");
        PlayerPrefs.SetString("Przychod", "");
        PlayerPrefs.SetString("PrzychodDrewna", "");
        PlayerPrefs.SetInt("CopperOre", 0);
        PlayerPrefs.SetInt("PoziomPostaci", 0);
        PlayerPrefs.SetInt("ObronaPostaci", 0);
        PlayerPrefs.SetInt("WitalnoscPostaci", 0);
        PlayerPrefs.SetInt("SilaPostaci", 0);
        PlayerPrefs.SetInt("MocPostaci", 0);
        PlayerPrefs.SetInt("UnikPostaci", 0);
        PlayerPrefs.SetInt("SzczesciePostaci", 0);
        PlayerPrefs.SetInt("AktHpPostaci", 5);
        PlayerPrefs.SetInt("MaxHpPostaci", 5);
        PlayerPrefs.SetInt("MinExpPostaci", 0);
        PlayerPrefs.SetInt("MaxExpPostaci", 1);
        PlayerPrefs.SetInt("MinObrPostaci", 0);
        PlayerPrefs.SetInt("MaxObrPostaci", 1);
        PlayerPrefs.SetInt("KosztStatystyk", 1);
        PlayerPrefs.SetInt("Przetapiane", 0);
        PlayerPrefs.SetInt("Przetopione", 0);
        PlayerPrefs.SetInt("WybudowanaKopalnia", 0);
        PlayerPrefs.SetInt("WybudowanyTartak", 0);
        PlayerPrefs.SetInt("WybudowanyDom", 0);
        PlayerPrefs.SetInt("WybudowanaHuta", 0);
        PlayerPrefs.SetInt("Walczone", 0);
        PlayerPrefs.SetInt("Wyleczony", 2);
        PlayerPrefs.SetInt("SzansaNaUnik", 0);
        PlayerPrefs.SetInt("SzansaNaKryt", 0);
        PlayerPrefs.SetString("SumaOffline", "");
        PlayerPrefs.SetInt("Bron", 0);
        PlayerPrefs.SetInt("ShopSlot1", 1);
        PlayerPrefs.SetInt("ShopSlot2", 1);
        PlayerPrefs.SetInt("ShopSlot3", 1);
        PlayerPrefs.SetInt("ShopSlot4", -1);
        PlayerPrefs.SetInt("ShopSlot5", -1);
        PlayerPrefs.SetInt("ShopSlot6", -1);
        PlayerPrefs.SetInt("ShopSlot7", -1);
        PlayerPrefs.SetInt("ShopSlot8", -1);
        PlayerPrefs.SetInt("ShopSlot9", -1);
        PlayerPrefs.SetInt("ShopSlot10", -1);
        PlayerPrefs.SetInt("ShopSlot11", -1);
        PlayerPrefs.SetInt("ShopSlot12", -1);
        PlayerPrefs.SetInt("EqSlot1", 0);
        PlayerPrefs.SetInt("EqSlot2", 0);
    }

    public void WrocDoMenu()
    {
        SceneManager.LoadScene(0);
    }

  
}
