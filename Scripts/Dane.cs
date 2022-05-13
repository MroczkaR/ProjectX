using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dane : MonoBehaviour
{
    public TMPro.TMP_Text kamiennemonety;
    public TMPro.TMP_Text poziompostaci;
    public TMPro.TMP_Text aktexppostaci;
    public TMPro.TMP_Text maxexppostaci;
    public TMPro.TMP_Text akthppostaci;
    public TMPro.TMP_Text maxhppostaci;
    public TMPro.TMP_Text minobrpostaci;
    public TMPro.TMP_Text maxobrpostaci;
    public TMPro.TMP_Text minobrmagpostaci;
    public TMPro.TMP_Text maxobrmagpostaci;
    public TMPro.TMP_Text obronapostaci;
    public TMPro.TMP_Text szansanaunikpostaci;
    public TMPro.TMP_Text szansanakrytpostaci;
    public TMPro.TMP_Text dostepnepktstatystyk;
    public TMPro.TMP_Text kosztstatystyk;
    public TMPro.TMP_Text statystykawitalonsc;
    public TMPro.TMP_Text statystykasila;
    public TMPro.TMP_Text statystykamoc;
    public TMPro.TMP_Text statystykaunik;
    public TMPro.TMP_Text statystykaszczescie;
    public TMPro.TMP_Text error;
    public TMPro.TMP_Text expBarProcents;
    public Image expBarCharacter;
    public Sprite WoodSword;
    public Button Bron;
    public Button Zbroja;
    public Button Helmet;
    public Button Tarcza;
    public Button Buty;
    public GameObject ItemPanel;
    public TMPro.TMP_Text NazwaPrzedmiotu;
    public TMPro.TMP_Text ObrazeniaPrzedmiotu;
    public TMPro.TMP_Text PancerzPrzedmiotu;
    public TMPro.TMP_Text WymaganyLvPrzedmiotu;
    Sprite ActualSprite;
    Color32 ActualColor;

    public static int poziompost = 0;
    public static int aktexppost = 0;
    public static int maxexppost = 1;
    public static int akthppost = 5;
    public static int maxhppost = 5;
    public static int minobrpost = 0;
    public static int maxobrpost = 1;
    public static int typeDmg = 1;
    public static int minobrmagpost = 0;
    public static int maxobrmagpost = 0;
    public static int obronapost = 0;
    public static int unikpost = 0;
    public static int krytpost = 0;
    public static int dostpktstat = 0;
    public static int kosztstat = 1;
    public static int wit = 0;
    public static int sila = 0;
    public static int moc = 0;
    public static int unik = 0;
    public static int szczescie = 0;
    public static int indexItemu = 0;
    int roundexp = 0;
    int actualItem = 0;
   // public static int ubranaBron = 0;

    int staty = 0;

    private void Start()
    {
        if(PlayerPrefs.GetInt("PoziomPostaci") != 0)
        {
            poziompost = PlayerPrefs.GetInt("PoziomPostaci");
            aktexppost = PlayerPrefs.GetInt("AktExpPostaci");
            maxexppost = PlayerPrefs.GetInt("MaxExpPostaci");
            akthppost = PlayerPrefs.GetInt("AktHpPostaci");
            maxhppost = PlayerPrefs.GetInt("MaxHpPostaci");
            minobrpost = PlayerPrefs.GetInt("MinObrPostaci");
            maxobrpost = PlayerPrefs.GetInt("MaxObrPostaci");
            minobrmagpost = PlayerPrefs.GetInt("MinObrMagPostaci");
            maxobrmagpost = PlayerPrefs.GetInt("MaxObrMagPostaci");
            dostpktstat = PlayerPrefs.GetInt("DostPktPostaci");
            kosztstat = PlayerPrefs.GetInt("KosztStatystyk");
            wit = PlayerPrefs.GetInt("WitalnoscPostaci");
            sila = PlayerPrefs.GetInt("SilaPostaci");
            moc = PlayerPrefs.GetInt("MocPostaci");
            unik = PlayerPrefs.GetInt("UnikPostaci");
            szczescie = PlayerPrefs.GetInt("SzczesciePostaci");
            unikpost = PlayerPrefs.GetInt("SzansaNaUnik");
            krytpost = PlayerPrefs.GetInt("SzansaNaKryt");
            obronapost = PlayerPrefs.GetInt("ObronaPostaci");

            if(maxobrpost == 0)
            {
                maxobrpost = 1;
            }
            if(maxhppost == 0)
            {
                maxhppost = 5;
                PlayerPrefs.SetInt("MaxHpPostaci", maxhppost);
            }
            if(kosztstat == 0)
            {
                kosztstat = 1;
            }
        }
        if(PlayerPrefs.GetInt("MinObrPostaci") != 0)
        {
            minobrpost = PlayerPrefs.GetInt("MinObrPostaci");
            maxobrpost = PlayerPrefs.GetInt("MaxObrPostaci");
        }

        if(PlayerPrefs.GetInt("ObronaPostaci") != 0)
        {
            obronapost = PlayerPrefs.GetInt("ObronaPostaci");
        }

            if(PlayerPrefs.GetInt("Bron") != 0)
            {
                ActualSprite = Resources.Load<Sprite>("EqId" + (PlayerPrefs.GetInt("Bron").ToString())); //new Color32(173, 110, 53, 255);
                Colors.CheckColor(PlayerPrefs.GetInt("Bron"));
                Bron.GetComponent<Image>().sprite = ActualSprite;
                Bron.GetComponent<Image>().color = Colors.ActualColor;
                
            }
            if(PlayerPrefs.GetInt("Zbroja") != 0)
            {
                ActualSprite = Resources.Load<Sprite>("EqId" + (PlayerPrefs.GetInt("Zbroja").ToString()));
                Colors.CheckColor(PlayerPrefs.GetInt("Zbroja"));
                Zbroja.GetComponent<Image>().sprite = ActualSprite;
                Zbroja.GetComponent<Image>().color = Colors.ActualColor;
            }
            if(PlayerPrefs.GetInt("Helmet") != 0)
            {
                ActualSprite = Resources.Load<Sprite>("EqId" + (PlayerPrefs.GetInt("Helmet").ToString()));
                Colors.CheckColor(PlayerPrefs.GetInt("Helmet"));
                Helmet.GetComponent<Image>().sprite = ActualSprite;
                Helmet.GetComponent<Image>().color = Colors.ActualColor;
            }
            if(PlayerPrefs.GetInt("Tarcza") != 0)
            {
                ActualSprite = Resources.Load<Sprite>("EqId" + (PlayerPrefs.GetInt("Tarcza").ToString()));
                Colors.CheckColor(PlayerPrefs.GetInt("Tarcza"));
                Tarcza.GetComponent<Image>().sprite = ActualSprite;
                Tarcza.GetComponent<Image>().color = Colors.ActualColor;
            }
             if(PlayerPrefs.GetInt("Buty") != 0)
            {
                ActualSprite = Resources.Load<Sprite>("EqId" + (PlayerPrefs.GetInt("Buty").ToString()));
                Colors.CheckColor(PlayerPrefs.GetInt("Buty"));
                Buty.GetComponent<Image>().sprite = ActualSprite;
                Buty.GetComponent<Image>().color = Colors.ActualColor;
            }



            poziompostaci.text = poziompost.ToString();
            aktexppostaci.text = aktexppost.ToString();
            maxexppostaci.text = maxexppost.ToString();
            akthppostaci.text = akthppost.ToString();
            maxhppostaci.text = maxhppost.ToString();
            expBarCharacter.fillAmount = (float)aktexppost / maxexppost;
            roundexp = (int)(((float)aktexppost / maxexppost) * 10000);
            expBarProcents.text = ((float)roundexp / 100).ToString() + "%";
            minobrpostaci.text = minobrpost.ToString();
            maxobrpostaci.text = maxobrpost.ToString();
            minobrmagpostaci.text = minobrmagpost.ToString();
            maxobrmagpostaci.text = maxobrmagpost.ToString();
            dostepnepktstatystyk.text = dostpktstat.ToString();
            kosztstatystyk.text = kosztstat.ToString();
            statystykawitalonsc.text = wit.ToString();
            statystykasila.text = sila.ToString();
            statystykamoc.text = moc.ToString();
            statystykaunik.text = unik.ToString();
            statystykaszczescie.text = szczescie.ToString();
            obronapostaci.text = obronapost.ToString();
            szansanaunikpostaci.text = unikpost.ToString();
            szansanakrytpostaci.text = krytpost.ToString();
    }

    public void OpenItemPanel(int IndexItemu)
    {
        ItemPanel.SetActive(true);
        Item.CheckItem(IndexItemu);
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

        public void ExitPanel()
    {
        ItemPanel.SetActive(false);
    }

    public void ZdejmijItem()
    {
        if(PlayerPrefs.GetInt("WagaEq") < PlayerPrefs.GetInt("MaxWagaEq"))
        {
        Ekwipunek.AddItem ++;
        if(actualItem == 1)
        {
            PlayerPrefs.SetInt("Bron", 0);
        }
        else if(actualItem == 2)
        {
            PlayerPrefs.SetInt("Zbroja", 0);
        }
        else if(actualItem == 3)
        {
            PlayerPrefs.SetInt("Helmet", 0);
        }
        else if(actualItem == 4)
        {
            PlayerPrefs.SetInt("Tarcza", 0);
        }
        else if(actualItem == 5)
        {
            PlayerPrefs.SetInt("Buty", 0);
        }
        minobrpost -= Item.MinObr;
        maxobrpost -= Item.MaxObr;
        obronapost -= Item.Pancerz;
        PlayerPrefs.SetInt("MinObrPostaci", minobrpost);
        PlayerPrefs.SetInt("MaxObrPostaci", maxobrpost);
        PlayerPrefs.SetInt("ObronaPostaci", obronapost);  
        ItemPanel.SetActive(false);
        SceneManager.LoadScene(7);
        }
        else
        {
                        
            ErrorScript.errortext = "Brak miejsca w Ekwipunku !";
            ErrorScript.showErrorPanel = true;
            
        }
    }

    public void BronBtn()
    {
        if(PlayerPrefs.GetInt("Bron") != 0)
        {
            OpenItemPanel(PlayerPrefs.GetInt("Bron"));
            actualItem = 1;
        }
        else
        {
            ErrorScript.errortext = "Nie masz ubranej broni";
            ErrorScript.showErrorPanel = true;
        }
    }
    public void ZbrojaBtn()
    {
            if(PlayerPrefs.GetInt("Zbroja") != 0)
        {
            OpenItemPanel(PlayerPrefs.GetInt("Zbroja"));
            actualItem = 2;
        }
        else
        {
            ErrorScript.errortext = "Nie masz ubranej zbroi";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void HelmetBtn()
    {
            if(PlayerPrefs.GetInt("Helmet") != 0)
        {
            OpenItemPanel(PlayerPrefs.GetInt("Helmet"));
            actualItem = 3;
        }
        else
        {
            ErrorScript.errortext = "Nie masz ubranego hełmu";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void TarczaBtn()
    {
            if(PlayerPrefs.GetInt("Tarcza") != 0)
        {
            OpenItemPanel(PlayerPrefs.GetInt("Tarcza"));
            actualItem = 4;
        }
        else
        {
            ErrorScript.errortext = "Nie masz ubranej tarczy";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void ButyBtn()
    {
                if(PlayerPrefs.GetInt("Buty") != 0)
        {
            OpenItemPanel(PlayerPrefs.GetInt("Buty"));
            actualItem = 5;
        }
        else
        {
            ErrorScript.errortext = "Nie masz ubranych butów";
            ErrorScript.showErrorPanel = true;
        }
    }

    public void ZmienNaSkille()
    {
        SceneManager.LoadScene(14);
        StartScript.aktscena = 14;
    }

    public void DodajWitalnosc()
    {
        if(dostpktstat > 0)
        {
            if(Zasoby.OldCoin >= kosztstat)
            {
                wit ++;
            akthppost += 5;
            maxhppost += 5;
            dostpktstat -- ;
            staty ++;
            Zasoby.OldCoin -= kosztstat;
            kosztstat ++;
            akthppostaci.text = akthppost.ToString();
            maxhppostaci.text = maxhppost.ToString();
            statystykawitalonsc.text = wit.ToString();
            dostepnepktstatystyk.text = dostpktstat.ToString();
            kosztstatystyk.text = kosztstat.ToString();
            kamiennemonety.text = Zasoby.OldCoin.ToString();
            PlayerPrefs.SetInt("AktHpPostaci", akthppost);
            PlayerPrefs.SetInt("MaxHpPostaci", maxhppost);
            PlayerPrefs.SetInt("WitalnoscPostaci", wit);
            PlayerPrefs.SetInt("DostPktPostaci", dostpktstat);
            PlayerPrefs.SetInt("KosztStatystyk", kosztstat);
            PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            }
            else
            {
            ErrorScript.errortext = "Za mało monet !";
            ErrorScript.showErrorPanel = true;
            }

        }
        else
        {
            ErrorScript.errortext = "Brak dostepnych pkt !";
            ErrorScript.showErrorPanel = true;
            
        }
    }
    public void DodajSile()
    {
        if(dostpktstat > 0)
        {
            if(Zasoby.OldCoin >= kosztstat)
            {
            sila ++;
            if(sila % 2 == 1)
            {
                maxobrpost += 1;
            }
            else
            {
                minobrpost += 1;
            }    
            dostpktstat -- ;
            staty ++;
            Zasoby.OldCoin -= kosztstat;
            kosztstat ++;
            minobrpostaci.text = minobrpost.ToString();
            maxobrpostaci.text = maxobrpost.ToString();
            statystykasila.text = sila.ToString();
            dostepnepktstatystyk.text = dostpktstat.ToString();
            kosztstatystyk.text = kosztstat.ToString();
            kamiennemonety.text = Zasoby.OldCoin.ToString();
            PlayerPrefs.SetInt("MinObrPostaci", minobrpost);
            PlayerPrefs.SetInt("MaxObrPostaci", maxobrpost);
            PlayerPrefs.SetInt("SilaPostaci", sila);
            PlayerPrefs.SetInt("DostPktPostaci", dostpktstat);
            PlayerPrefs.SetInt("KosztStatystyk", kosztstat);
            PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            }
            else
            {
            ErrorScript.errortext = "Za mało monet !";
            ErrorScript.showErrorPanel = true;
            }

        }
        else
        {     
            ErrorScript.errortext = "Brak dostepnych pkt !";
            ErrorScript.showErrorPanel = true;               
        }
    }

    public void DodajMoc()
    {
        if(dostpktstat > 0)
        {
            if(Zasoby.OldCoin >= kosztstat)
            {
            moc ++;
            maxobrmagpost += 2;
            minobrmagpost += 1;    
            dostpktstat -- ;
            staty ++;
            Zasoby.OldCoin -= kosztstat;
            kosztstat ++;
            minobrmagpostaci.text = minobrmagpost.ToString();
            maxobrmagpostaci.text = maxobrmagpost.ToString();
            statystykamoc.text = moc.ToString();
            dostepnepktstatystyk.text = dostpktstat.ToString();
            kamiennemonety.text = Zasoby.OldCoin.ToString();
            PlayerPrefs.SetInt("MinObrMagPostaci", minobrmagpost);
            PlayerPrefs.SetInt("MaxObrMagPostaci", maxobrmagpost);
            PlayerPrefs.SetInt("MocPostaci", moc);
            PlayerPrefs.SetInt("DostPktPostaci", dostpktstat);
            PlayerPrefs.SetInt("KosztStatystyk", kosztstat);
            PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            }
            else
            {
            ErrorScript.errortext = "Za mało monet !";
            ErrorScript.showErrorPanel = true;
            }

        }
        else
        {     
            ErrorScript.errortext = "Brak dostepnych pkt !";
            ErrorScript.showErrorPanel = true; 
             
        }
    }

    public void DodajUnik()
    {
        if(dostpktstat > 0)
        {
            if(Zasoby.OldCoin >= kosztstat)
            {
            unik ++;
            unikpost ++;
            dostpktstat -- ;
            staty ++;
            Zasoby.OldCoin -= kosztstat;
            kosztstat ++;
            statystykaunik.text = unik.ToString();
            szansanaunikpostaci.text = unikpost.ToString();
            dostepnepktstatystyk.text = dostpktstat.ToString();
            kosztstatystyk.text = kosztstat.ToString();
            kamiennemonety.text = Zasoby.OldCoin.ToString();
            PlayerPrefs.SetInt("SzansaNaUnik", unikpost);
            PlayerPrefs.SetInt("UnikPostaci", unik);
            PlayerPrefs.SetInt("DostPktPostaci", dostpktstat);
            PlayerPrefs.SetInt("KosztStatystyk", kosztstat);
            PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            }
            else
            {
            ErrorScript.errortext = "Za mało monet !";
            ErrorScript.showErrorPanel = true;
            }

        }
        else
        {
            ErrorScript.errortext = "Brak dostepnych pkt !";
            ErrorScript.showErrorPanel = true;
            
        }
    }

    public void DodajSzczescie()
    {
        if(dostpktstat > 0)
        {
            if(Zasoby.OldCoin >= kosztstat)
            {
            szczescie ++;
            krytpost ++;
            dostpktstat -- ;
            staty ++;
            Zasoby.OldCoin -= kosztstat;
            kosztstat ++;
            statystykaszczescie.text = szczescie.ToString();
            szansanakrytpostaci.text = krytpost.ToString();
            dostepnepktstatystyk.text = dostpktstat.ToString();
            kosztstatystyk.text = kosztstat.ToString();
            kamiennemonety.text = Zasoby.OldCoin.ToString();
            PlayerPrefs.SetInt("SzansaNaKryt", krytpost);
            PlayerPrefs.SetInt("SzczesciePostaci", szczescie);
            PlayerPrefs.SetInt("DostPktPostaci", dostpktstat);
            PlayerPrefs.SetInt("KosztStatystyk", kosztstat);
            PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            }
            else
            {
            ErrorScript.errortext = "Za mało monet !";
            ErrorScript.showErrorPanel = true;
            }

        }
        else
        {
            ErrorScript.errortext = "Brak dostepnych pkt !";
            ErrorScript.showErrorPanel = true;
            
        }
    }
    

}
