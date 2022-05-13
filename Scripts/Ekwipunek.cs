using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Ekwipunek : MonoBehaviour
{
    public GameObject ItemPanel;
    public TMPro.TMP_Text NazwaPrzedmiotu;
    public TMPro.TMP_Text ObrazeniaPrzedmiotu;
    public TMPro.TMP_Text PancerzPrzedmiotu;
    public TMPro.TMP_Text WymaganyLvPrzedmiotu;
    public static int AddItem = 0;
    public static int WagaEq = 0;
    public static int MaxWagaEq = 10;
    int IndexSlotu;
    int IndexObrazka;
    string eqSlot;
    int[] Sloty = new int [100];
    Button Slot;
    int x = 11;
    public Sprite WoodSword;
    public Sprite SkorzanaZbroja;
    public Sprite Empty;
    Sprite AcctuallyImage;

    void Start()
    {
        WagaEq = PlayerPrefs.GetInt("WagaEq");
        MaxWagaEq = PlayerPrefs.GetInt("MaxWagaEq");
        if(MaxWagaEq < 10)
        {
            MaxWagaEq = 10;
        }
    for(int i = 1; i< 100; i++)
    {
        Sloty[i] = PlayerPrefs.GetInt("EqSlot" + i.ToString());
    }  


        if(AddItem > 0)
        {
            DodajPrzedmiot();
            WagaEq ++;
            PlayerPrefs.SetInt("WagaEq", WagaEq);
            AddItem --;
        }

        CheckEq();


              
    }

    public void BtnTest(Button Btn)
    {
        Slot = Btn;  
        for(int i = 1; i < x; i++)
        {
            if(Btn.name == i.ToString())
            {
                IndexSlotu = i;
            }
        }

    }

     void CheckEq()
    {
        
        for(int slotX = 1; slotX < x; slotX++)
        {
            Slot = GameObject.Find(slotX.ToString()).GetComponent<Button>();
            if(PlayerPrefs.GetInt("EqSlot" + slotX.ToString()) != 0)
        {
            IndexObrazka = Sloty[slotX];
            SetAcctuallyImage();
            Slot.GetComponent<Image>().sprite = AcctuallyImage;
            Colors.CheckColor(IndexObrazka);
            Slot.GetComponent<Image>().color = Colors.ActualColor;
            Slot.gameObject.SetActive(true);
        }
        else
        {
            Sloty[slotX] = 0;
            Slot.GetComponent<Image>().sprite = Empty;
            Slot.gameObject.SetActive(false);
        }
        }

    }

    void SetAcctuallyImage()
    {

        AcctuallyImage = Resources.Load<Sprite>("EqId" + IndexObrazka.ToString());
    }


    public void DodajPrzedmiot()
    {
        SetAcctuallyImage();     
        for(int i = 1; i < x; i++)
        {
            if(Sloty[i] == 0)
            {
                Slot = GameObject.Find(i.ToString()).GetComponent<Button>();
                IndexObrazka = Item.Index;
                Slot.GetComponent<Image>().sprite = AcctuallyImage;
                Colors.CheckColor(IndexObrazka);
                Slot.GetComponent<Image>().color = Colors.ActualColor;
                Sloty[i] = Item.Index;
                PlayerPrefs.SetInt("EqSlot" + i.ToString(), Item.Index);
                i = x;
            }
        }
        
    }

    public void ExitPanel()
    {
        ItemPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        ItemPanel.SetActive(true);
        Item.CheckItem(Sloty[IndexSlotu]);
        NazwaPrzedmiotu.text = Item.Nazwa;
        WymaganyLvPrzedmiotu.text = "Wymagany Poziom :   " + Item.WymaganyLv.ToString();
        if(Item.Index < 100)
        {
            ObrazeniaPrzedmiotu.text = "Obrażenia :   " + Item.MinObr.ToString() + "   -   " + Item.MaxObr.ToString();
            PancerzPrzedmiotu.text = "";
        }
        else
        {
            PancerzPrzedmiotu.text = "Pancerz :   " + Item.Pancerz.ToString();
            ObrazeniaPrzedmiotu.text = "";
        } 

    }

    void MakeEmpty()
    {
        for(int i = 0; i < x; i++)
        {
            if(IndexSlotu == i)
            {
                Slot = GameObject.Find(i.ToString()).GetComponent<Button>();
                Slot.GetComponent<Image>().sprite = Empty;
                Sloty[i] = 0;
                PlayerPrefs.SetInt("EqSlot" + i.ToString(), 0);
            }
        }
    }

    public void WyposazItem()
    {
       if(Sloty[IndexSlotu] < 100)
       {
        if(PlayerPrefs.GetInt("Bron") == 0)
        {
            
            PlayerPrefs.SetInt("Bron", Sloty[IndexSlotu]);
            DodajStatyItemu();
        }
        else
        {
            ErrorScript.errortext = "Masz już ubrana broń !";
            ErrorScript.showErrorPanel = true;
        }
       }
       else if(Sloty[IndexSlotu] < 200)
       {
            if(PlayerPrefs.GetInt("Zbroja") == 0)
        {
            PlayerPrefs.SetInt("Zbroja", Sloty[IndexSlotu]);
            DodajStatyItemu();
        }
         else
        {
            ErrorScript.errortext = "Masz już ubrana zbroje !";
            ErrorScript.showErrorPanel = true;
        }
       }
        else if(Sloty[IndexSlotu] < 300)
       {
            if(PlayerPrefs.GetInt("Helmet") == 0)
        {
            PlayerPrefs.SetInt("Helmet", Sloty[IndexSlotu]);
            DodajStatyItemu();
        }
                else
        {
            ErrorScript.errortext = "Masz już ubrany Hełm !";
            ErrorScript.showErrorPanel = true;
        }
       }
       else if(Sloty[IndexSlotu] < 400)
       {
           if(PlayerPrefs.GetInt("Tarcza") == 0)
           {
                PlayerPrefs.SetInt("Tarcza" , Sloty[IndexSlotu]);
                DodajStatyItemu();
           }
            else
          {
            ErrorScript.errortext = "Masz już ubraną Tarczę !";
            ErrorScript.showErrorPanel = true;
          }
       }
        else if(Sloty[IndexSlotu] < 500)
       {
           if(PlayerPrefs.GetInt("Buty") == 0)
           {
                PlayerPrefs.SetInt("Buty" , Sloty[IndexSlotu]);
                DodajStatyItemu();

           }
            else
          {
            ErrorScript.errortext = "Masz już ubrane Buty !";
            ErrorScript.showErrorPanel = true;
          }
       }


        

    }

    void DodajStatyItemu()
    {
        Dane.minobrpost += Item.MinObr;
        Dane.maxobrpost += Item.MaxObr;
        Dane.obronapost += Item.Pancerz;
        PlayerPrefs.SetInt("MinObrPostaci", Dane.minobrpost);
        PlayerPrefs.SetInt("MaxObrPostaci", Dane.maxobrpost);
        PlayerPrefs.SetInt("ObronaPostaci", Dane.obronapost);
        Item.CheckItem(Sloty[IndexSlotu]);
        WagaEq --;
        PlayerPrefs.SetInt("WagaEq", WagaEq);
        MakeEmpty();
        SceneManager.LoadScene(2);
        StartScript.aktscena = 2;
    }
}
