using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Shop : MonoBehaviour
{
    public TMPro.TMP_Text tOldCoins;
    public TMPro.TMP_Text tWood;
    public TMPro.TMP_Text tStone;
    public TMPro.TMP_Text NazwaPrzedmiotu;
    public TMPro.TMP_Text ObrazeniaPrzedmiotu;
    public TMPro.TMP_Text PancerzPrzedmiotu;
    public TMPro.TMP_Text WymaganyLvPrzedmiotu;
    public TMPro.TMP_Text CenaPrzedmiotu;
    public TMPro.TMP_Text NazwaSurowca;
    public InputField InputValue;
    public TMPro.TMP_Text SellCost;
    public TMPro.TMP_Text BuyCost;
    public TMPro.TMP_Text TekstSurePanelu;
    public TMPro.TMP_Text IloscSurkiSP;
    public TMPro.TMP_Text CenaSurkiSP;
    public Image SurkaImage;
    int sellCena;
    int buyCena;
    int[] Sloty = new int [100];
    int IndexSlotu;
    public GameObject BuyPanel;
    public GameObject ValutesPanel;
    public GameObject SurePanel;
    Button Slot;
    int x = 13;
    Sprite AcctuallyImage;
    /*public Button Slot1;
    public Button Slot2;
    public Button Slot3;
    public Button Slot4;
    public Button Slot5;
    public Button Slot6;
    public Button Slot7;
    public Button Slot8;
    public Button Slot9;
    public Button Slot10;
    public Button Slot11;
    public Button Slot12;*/
    public Sprite WoodSword;
    public Sprite Empty;
    public Sprite Drewno;
    public Sprite Kamien;
    int inputedValue = 0;
    int oknoSurki = 0;
    double Surowiec;
    bool BuyOrSell = true;

    void Start()
    {

        CheckSlots();
        
    }

    void CheckSlots()
    {
        for(int i = 1; i<13; i++)
        {
            if(PlayerPrefs.GetInt("ShopSlot" + i.ToString()) != 0)
            {
                Sloty[i] = PlayerPrefs.GetInt("ShopSlot" + i.ToString());
                if(Sloty[i] > 0)
                {
                    AcctuallyImage = Resources.Load<Sprite>("EqId" + Sloty[i].ToString());
                    Slot = GameObject.Find("0" + i.ToString()).GetComponent<Button>();
                    Colors.CheckColor(Sloty[i]);
                    Slot.GetComponent<Image>().sprite = AcctuallyImage;
                    Slot.GetComponent<Image>().color = Colors.ActualColor;
                }
                
            }
            else
            {
                Sloty[i] = 0;
                Slot = GameObject.Find("0" + i.ToString()).GetComponent<Button>();
                Slot.GetComponent<Image>().sprite = Empty;
                Slot.gameObject.SetActive(false);

                
            }
        }

        
    }

        public void BtnTest(Button Btn)
    {
        Slot = Btn;  
        for(int i = 1; i < x; i++)
        {
            if(Btn.name == "0" + i.ToString())
            {
                IndexSlotu = i;
                if(PlayerPrefs.GetInt("ShopSlot" + i.ToString()) >= 0)
                {
                    OpenBuyPanel();
                }
                else
                {
                    ClickLockedSlot();
                }
            }
        }


    }

    public void ClickLockedSlot()
    {
        ErrorScript.errortext = "Ten Slot Sklepu nie został jeszcze odblokowany";
        ErrorScript.showErrorPanel = true;
    }


    void ChangeImage()
    {
       for(int i = 1; i < 13; i++)
        {
            if(IndexSlotu == i)
            {
                Sloty[i] = 0;
                PlayerPrefs.SetInt("ShopSlotX", -1);
                PlayerPrefs.SetInt("ShopSlot" + i.ToString(), 0);
            }
        }

    }

    void OpenBuyPanel()
    {
        Item.CheckItem(Sloty[IndexSlotu]);
        BuyPanel.SetActive(true);
        NazwaPrzedmiotu.text = Item.Nazwa;
        WymaganyLvPrzedmiotu.text = "Wymagany Poziom :   " + Item.WymaganyLv.ToString();
        if(Sloty[IndexSlotu] < 100)
        {
             ObrazeniaPrzedmiotu.text = "Obrażenia :   " + Item.MinObr.ToString() + "   -   " + Item.MaxObr.ToString();
             PancerzPrzedmiotu.text = "";
        }
        else if(Sloty[IndexSlotu] < 500)
        {
            PancerzPrzedmiotu.text = "Pancerz :   " + Item.Pancerz.ToString();
            ObrazeniaPrzedmiotu.text = "";        }
       
        CenaPrzedmiotu.text = Item.Cena.ToString();
    }

    public void BuyItem()
    {
        if(Zasoby.OldCoin >= Item.Cena)
        {
            if(PlayerPrefs.GetInt("WagaEq") < PlayerPrefs.GetInt("MaxWagaEq"))
            {
                Zasoby.OldCoin -= Item.Cena;
                PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
                tOldCoins.text = Zasoby.OldCoin.ToString();
                ChangeImage();
                Ekwipunek.AddItem ++;
                BuyPanel.SetActive(false);
                SceneManager.LoadScene(7);
            }
            else
            {
                ErrorScript.errortext = "Brak miejsca w Ekwipunku !";
                ErrorScript.showErrorPanel = true;
            }
        }
        else
        {
            ErrorScript.errortext = "Nie wystarczajaca ilosc monet !";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void DontBuyItem()
    {
        BuyPanel.SetActive(false);
    }

    public void RefreshShop()
    {
        if(Sloty[5] < 0)
        {
            for(int i = 1; i < 5; i++)
            {
                if(Sloty[i] == 0)
                {
                    int losowanieItemku = UnityEngine.Random.Range(1, 501);
                    if(losowanieItemku < 101)
                    {
                        losowanieItemku = 1;
                    }
                    else if(losowanieItemku < 201)
                    {
                        losowanieItemku = 101;
                    }
                    else if(losowanieItemku < 301)
                    {
                        losowanieItemku = 201;
                    }
                    else if(losowanieItemku < 401)
                    {
                        losowanieItemku = 301;
                    }
                    else if(losowanieItemku < 501)
                    {
                        losowanieItemku = 401;
                    }
                    PlayerPrefs.SetInt("ShopSlot" + i.ToString(), losowanieItemku);
                    SceneManager.LoadScene(0);
                    SceneManager.LoadScene(6);
                }
            }
        }
    }

    public void OpenStonePanel()
    {
        NazwaSurowca.text = "Kamień";
        ValutesPanel.SetActive(true);
        oknoSurki = 2;
    }

    public void OpenWoodPanel()
    {
        NazwaSurowca.text = "Drewno";
        ValutesPanel.SetActive(true);
        oknoSurki = 1;
    }

    public void CloseValutesPanel()
    {
        ValutesPanel.SetActive(false);
    }

    public void InputValueChanged()
    {

            inputedValue = int.Parse(InputValue.text);
            sellCena = inputedValue / 40;
            buyCena = inputedValue / 10;
            if(inputedValue % 10 != 0)
            {
                buyCena ++;
            }
            SellCost.text = sellCena.ToString();
            BuyCost.text = buyCena.ToString();
        
    }

    public void KupSurowiec()
    {
        BuyOrSell = true;
        if(Zasoby.OldCoin >= buyCena)
        {
        SurePanel.SetActive(true);
        ZmienImage();
        IloscSurkiSP.text = inputedValue.ToString();
        CenaSurkiSP.text = buyCena.ToString();
        TekstSurePanelu.text = "Czy napewno chcesz kupić";
        }
        else
        {
            ErrorScript.errortext = "Nie wystarczajaca ilosc monet !";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void SprzedajSurowiec()
    {
        BuyOrSell = false;
        if(oknoSurki == 1)
        {
            Surowiec = Zasoby.Wood;
        }
        else if(oknoSurki == 2)
        {
            Surowiec = Zasoby.Stone;
        }
        if(Surowiec >= inputedValue)
        {
            SurePanel.SetActive(true);
            ZmienImage();
            IloscSurkiSP.text = inputedValue.ToString();
            CenaSurkiSP.text = sellCena.ToString();
            TekstSurePanelu.text = "Czy napewno chcesz sprzedać";
        }
        else
        {
            if(oknoSurki == 1)
            {
                ErrorScript.errortext = "Nie wystarczająca ilość drewna !";
            }
            else if(oknoSurki == 2)
            {
                ErrorScript.errortext = "Nie wystarczająca ilość kamienia !";
            }
            ErrorScript.showErrorPanel = true;
            
        }
    }

    void DodajKamien()
    {
        if(BuyOrSell == true)
        {
            Zasoby.Stone += inputedValue;
            Zasoby.OldCoin -= buyCena;
        }
        else
        {
            Zasoby.Stone -= inputedValue;
            Zasoby.OldCoin += sellCena;
        }
        tStone.text = Zasoby.Stone.ToString();
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        tOldCoins.text = Zasoby.OldCoin.ToString();
        PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
    }

    void DodajDrewno()
    {
        if(BuyOrSell == true)
        {
            Zasoby.Wood += inputedValue;
            Zasoby.OldCoin -= buyCena;
        }
        else
        {
            Zasoby.Wood -= inputedValue;
            Zasoby.OldCoin += sellCena;
        }
        tWood.text = Zasoby.Wood.ToString();
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
        tOldCoins.text = Zasoby.OldCoin.ToString();
        PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
        
    }

    public void Accept()
    {

            if(oknoSurki == 1)
        {
            DodajDrewno();
        }
            else if(oknoSurki == 2)
        {
            DodajKamien();
        }
            SurePanel.SetActive(false);
            ValutesPanel.SetActive(false);
            InputValue.text = "0";

        
    }

    public void Cancel()
    {
        SurePanel.SetActive(false);
        ValutesPanel.SetActive(false);
        InputValue.text = "0";
    }

    void ZmienImage()
    {
        if(oknoSurki == 1)
        {
            SurkaImage.sprite = Drewno;
        }
        else if(oknoSurki == 2)
        {
            SurkaImage.sprite = Kamien;
        }
    }
    
}
