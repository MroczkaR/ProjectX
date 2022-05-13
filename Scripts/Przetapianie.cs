using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Przetapianie : MonoBehaviour
{

     public TMPro.TMP_Text kamien;
     public TMPro.TMP_Text kamiennemonety;
     public TMPro.TMP_Text drewno;
     public TMPro.TMP_Text time;
     public TMPro.TMP_Text kolejkaPrzetapiania;
     public TMPro.TMP_Text time2;
     public TMPro.TMP_Text przetopioneT;
     public Slider sliderTime;

     public static int przetapiane;
    
     string dzienteraz;
     string godzinateraz;
     string minutateraz;
     string sekundateraz;
     public static int dzienskonczenia;
     public static int godzinaskonczenia; 
     public static int minutaskonczenia;
     public static int sekundaskonczenia;
     int minutadokonca;
     int sekundadokonca;
     int przetopione = 0;

     int sekundytworzenia = 60;
     int sumasekunddokonca = 0;
     int poziomhutnika;
    void Start()
     {
         if(PlayerPrefs.GetInt("Przetapiane") != 0)
         {
             przetapiane = PlayerPrefs.GetInt("Przetapiane");
             dzienskonczenia = PlayerPrefs.GetInt("DzienSkoncz");
             godzinaskonczenia = PlayerPrefs.GetInt("GodzSkoncz");
             minutaskonczenia = PlayerPrefs.GetInt("MinSkoncz");
             sekundaskonczenia = PlayerPrefs.GetInt("SekSkoncz");
         }
         else
         {
             przetapiane = 0;
         }

        /* Button TestBTN = GameObject.Find("CeleronZ").GetComponent<Button>();
         Debug.Log(TestBTN.name);
         TestBTN.gameObject.SetActive(false);*/

        przetopione = PlayerPrefs.GetInt("Przetopione");
        przetopioneT.text = przetopione.ToString();
         StartCoroutine(Czas());
     }
    public void PrzetopKamien()
    {
        if(Zasoby.Stone >= 10)
        {
            if(Zasoby.Wood >= 10)
            {
            Zasoby.Stone -= 10;
            Zasoby.Wood -= 10;
            Zasoby.Stone = Math.Round(Zasoby.Stone, 2);
            Zasoby.Wood = Math.Round(Zasoby.Wood, 2);
            PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
            PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
            kamien.text = Zasoby.Stone.ToString();
            drewno.text = Zasoby.Wood.ToString();             
            
            if(przetapiane == 0)
            {
                dzienteraz = System.DateTime.Now.ToString("dd");
                godzinateraz = System.DateTime.Now.ToString("HH");
                minutateraz = System.DateTime.Now.ToString("mm");
                sekundateraz = System.DateTime.Now.ToString("ss");
            }
            else
            {
                dzienteraz = dzienskonczenia.ToString();
                godzinateraz = godzinaskonczenia.ToString();
                minutateraz = minutaskonczenia.ToString();
                sekundateraz = sekundaskonczenia.ToString();
            }

            sekundaskonczenia = int.Parse(sekundateraz) + sekundytworzenia;
            minutaskonczenia = int.Parse(minutateraz) + (sekundaskonczenia / 60);
            godzinaskonczenia = int.Parse(godzinateraz) + (minutaskonczenia / 60);
            dzienskonczenia = int.Parse(dzienteraz) + (godzinaskonczenia / 24);
            sekundaskonczenia = sekundaskonczenia % 60;
            minutaskonczenia = minutaskonczenia % 60;
            godzinaskonczenia = godzinaskonczenia % 24;
            dzienskonczenia = dzienskonczenia % 30;
            przetapiane ++;
            PlayerPrefs.SetInt("DzienSkoncz", dzienskonczenia);
            PlayerPrefs.SetInt("SekSkoncz", sekundaskonczenia);
            PlayerPrefs.SetInt("MinSkoncz", minutaskonczenia);
            PlayerPrefs.SetInt("GodzSkoncz", godzinaskonczenia);
            PlayerPrefs.SetInt("Przetapiane", przetapiane);
            kolejkaPrzetapiania.text = (przetapiane - 1).ToString();
            StartCoroutine(Czas());
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

    public void DodajPrzetopione()
    {
        Zasoby.OldCoin += przetopione;
        przetopione = 0;
        przetopioneT.text = "0";
        kamiennemonety.text = Zasoby.OldCoin.ToString();
        PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
        PlayerPrefs.SetInt("Przetopione", przetopione);
    }

    void DodajDoPrzetopionych()
    {
        przetopione += przetapiane;
        przetapiane = 0;
        kolejkaPrzetapiania.text = "0";
        time.text = "";
        time2.text = "";
        przetopioneT.text = przetopione.ToString();
        PlayerPrefs.SetInt("Przetapiane", przetapiane);
        PlayerPrefs.SetInt("Przetopione", przetopione);
    }

    IEnumerator Czas()
        {
            
            while(przetapiane > 0)
            {

                dzienteraz = System.DateTime.Now.ToString("dd");
                godzinateraz = System.DateTime.Now.ToString("HH");
                minutateraz = System.DateTime.Now.ToString("mm");
                sekundateraz = System.DateTime.Now.ToString("ss");
                if(int.Parse(godzinateraz) < godzinaskonczenia)
                {
                    minutadokonca = minutaskonczenia + 60;
                }
                else
                {
                    minutadokonca = minutaskonczenia;
                }
                sumasekunddokonca = (minutadokonca - int.Parse(minutateraz)) * 60 + (sekundaskonczenia - int.Parse(sekundateraz));
                minutadokonca = sumasekunddokonca / 60;
                sekundadokonca = sumasekunddokonca % 60;
                if(sekundadokonca >= 10)
                {
                    time.text = minutadokonca.ToString() + ":" + sekundadokonca.ToString();
                    time2.text = "0:" + sekundadokonca.ToString();
                }
                else
                {
                    time.text = minutadokonca.ToString() + ":0" + sekundadokonca.ToString();
                    time2.text = "0:0" + sekundadokonca.ToString();
                }
                sliderTime.value = (float)(sekundytworzenia - sekundadokonca) / sekundytworzenia;
                if(dzienskonczenia < int.Parse(dzienteraz))
                {
                    DodajDoPrzetopionych();        
                }
                else if(godzinaskonczenia < int.Parse(godzinateraz) && dzienskonczenia == int.Parse(dzienteraz))
                {
                    DodajDoPrzetopionych();
                }
                else if(minutadokonca <= 0 && sekundadokonca < 0)
                {
                    DodajDoPrzetopionych();
                }
                else if((sumasekunddokonca / sekundytworzenia) + 1 < przetapiane)
                {
                    przetopione += (przetapiane - ((sumasekunddokonca / sekundytworzenia) + 1));
                    przetapiane -= (przetapiane - ((sumasekunddokonca / sekundytworzenia) + 1));
                    kolejkaPrzetapiania.text = (przetapiane - 1).ToString();
                    przetopioneT.text = przetopione.ToString();
                    PlayerPrefs.SetInt("Przetopione", przetopione);
                    PlayerPrefs.SetInt("Przetapiane", przetapiane);
                }
                yield return new WaitForSeconds(1);
                
            }
        }
}
