using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Leczenie : MonoBehaviour
{
    public TMPro.TMP_Text akthp;
    public TMPro.TMP_Text maxhp;
    public TMPro.TMP_Text czasleczenia;
    int iloschp = 1;
    int czashp = 5;
    int sumaczasuleczenia = 0;
    int czaswskrzeszenia = 0;

    string dzienteraz;
    string godzinateraz;
    string minutateraz;
    string sekundateraz;
    int dzienkoncaleczenia;
    int godzinakoncaleczenia;
    int minutakoncaleczenia;
    int sekundakoncaleczenia;
    int mindokonca;
    int sekdokonca;
    //bool wyleczony = false;
    int sumasekdokonca;

    private void Start()
    {
        if(PlayerPrefs.GetInt("MaxHpPostaci") == 0)
            {
                PlayerPrefs.SetInt("MaxHpPostaci", 5);
            }
        else
        {
            Dane.maxhppost = PlayerPrefs.GetInt("MaxHpPostaci");
        }
        if(PlayerPrefs.GetInt("Walczone") == 1)
        {
            Dane.akthppost = PlayerPrefs.GetInt("AktHpPostaci");
        }
        else
        {
            Dane.akthppost = 5;
        }
        if(PlayerPrefs.GetInt("Wyleczony") == 1)
        {
            sekundakoncaleczenia = PlayerPrefs.GetInt("SekKoncaLeczenia");
            minutakoncaleczenia = PlayerPrefs.GetInt("MinKoncaLeczenia");
            godzinakoncaleczenia = PlayerPrefs.GetInt("GodzKoncaLeczenia");
            dzienkoncaleczenia = PlayerPrefs.GetInt("DzienKoncaLeczenia");
            StartCoroutine(Czas());
        }
        Dane.poziompost = PlayerPrefs.GetInt("PoziomPostaci");
        akthp.text = Dane.akthppost.ToString();
        maxhp.text = Dane.maxhppost.ToString();
    }

    public void Ulecz()
    {
      
        if(iloschp == 1)
        {
            sumaczasuleczenia = (Dane.maxhppost - Dane.akthppost) * czashp;
        }
        else
        {
            sumaczasuleczenia = (Dane.maxhppost - Dane.akthppost) / iloschp;
        }
        if(Dane.akthppost == 0)
        {
            czaswskrzeszenia = czashp * 10 * Dane.poziompost;
            sumaczasuleczenia -= czashp;
            PlayerPrefs.SetInt("CzasWstania", czaswskrzeszenia);
            
        }
        else
        {
            czaswskrzeszenia = 0;
            PlayerPrefs.SetInt("CzasWstania", czaswskrzeszenia);
        }
        PlayerPrefs.SetInt("CzasLeczenia", sumaczasuleczenia);
        sumaczasuleczenia = czaswskrzeszenia + sumaczasuleczenia;
        dzienteraz = System.DateTime.Now.ToString("dd");
        godzinateraz = System.DateTime.Now.ToString("HH");
        minutateraz = System.DateTime.Now.ToString("mm");
        sekundateraz = System.DateTime.Now.ToString("ss");
        PlayerPrefs.SetInt("Wyleczony", 1);
        sekundakoncaleczenia = sumaczasuleczenia + int.Parse(sekundateraz);
        minutakoncaleczenia = int.Parse(minutateraz) + sekundakoncaleczenia / 60;
        godzinakoncaleczenia = int.Parse(godzinateraz) + minutakoncaleczenia / 60;
        dzienkoncaleczenia = int.Parse(dzienteraz) + godzinakoncaleczenia / 24;
        sekundakoncaleczenia = sekundakoncaleczenia % 60;
        minutakoncaleczenia = minutakoncaleczenia % 60;
        godzinakoncaleczenia = godzinakoncaleczenia % 24;
        dzienkoncaleczenia = dzienkoncaleczenia % 30;
        PlayerPrefs.SetInt("SekKoncaLeczenia", sekundakoncaleczenia);
        PlayerPrefs.SetInt("MinKoncaLeczenia", minutakoncaleczenia);
        PlayerPrefs.SetInt("GodzKoncaLeczenia", godzinakoncaleczenia);
        PlayerPrefs.SetInt("DzienKoncaLeczenia", dzienkoncaleczenia);
        StartCoroutine(Czas());
        
    }

    void Wylecz()
    {
            Dane.akthppost = Dane.maxhppost;
            akthp.text = Dane.akthppost.ToString();
            PlayerPrefs.SetInt("AktHpPostaci", Dane.akthppost);
            PlayerPrefs.SetInt("Wyleczony", 2);
            czasleczenia.text = "";
    }

    IEnumerator Czas()
    {
        while(PlayerPrefs.GetInt("Wyleczony") != 2)
        {
            dzienteraz = System.DateTime.Now.ToString("dd");
        godzinateraz = System.DateTime.Now.ToString("HH");
        minutateraz = System.DateTime.Now.ToString("mm");
        sekundateraz = System.DateTime.Now.ToString("ss");
        if(int.Parse(godzinateraz) < godzinakoncaleczenia)
                {
                    mindokonca = minutakoncaleczenia + 60;
                }
                else
                {
                    mindokonca = minutakoncaleczenia;
                }
                sumasekdokonca = (minutakoncaleczenia - int.Parse(minutateraz)) * 60 + (sekundakoncaleczenia - int.Parse(sekundateraz));
                mindokonca = sumasekdokonca / 60;
                sekdokonca = sumasekdokonca % 60;
                if(sekdokonca >= 10)
                {
                    czasleczenia.text = mindokonca.ToString() + ":" + sekdokonca.ToString();
                }
                else
                {
                    czasleczenia.text = mindokonca.ToString() + ":0" + sekdokonca.ToString();
                }
        
        if(int.Parse(godzinateraz) > godzinakoncaleczenia && int.Parse(dzienteraz) >= dzienkoncaleczenia)
        {
            Wylecz();
        }
        else if(int.Parse(dzienteraz) > dzienkoncaleczenia)
        {
            Wylecz();
        }
        if(mindokonca <= 0 && sekdokonca < 0)
        {
            Wylecz();
        }
        else if(sumasekdokonca < PlayerPrefs.GetInt("CzasLeczenia"))
        {
            int hpniewyleczone;
            hpniewyleczone = sumasekdokonca / czashp;
            if(sumasekdokonca % 5 != 0)
            {
                hpniewyleczone++;
            }
            Dane.akthppost = Dane.maxhppost - hpniewyleczone;
            akthp.text = Dane.akthppost.ToString();
            PlayerPrefs.SetInt("AktHpPostaci", Dane.akthppost); 
        }
        yield return new WaitForSeconds(1);
        }
    }

    public void Stop()
    {
        StopCoroutine(Czas());
        PlayerPrefs.SetInt("Wyleczony", 2);
        czasleczenia.text = "";
    }
}
