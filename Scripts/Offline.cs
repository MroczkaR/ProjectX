using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Offline : MonoBehaviour
{
    public GameObject OfflinePanel;
    public TMPro.TMP_Text OfflineDrewno;
    public TMPro.TMP_Text OfflineKamien;
    public TMPro.TMP_Text OfflineTime;
    
    public static string dzien;
    public static string godziny;
    public static string minuty;
    public static double sumaprzychoduoffline;
    public static double sumaprzychoduofflinedrewno;
    string minutyteraz;
    string godzinyteraz;
    string dzienteraz;
    public static double czasoffline = 0;

    public static double przychodoffline;
    public static double przychodOfflineDrewno;
    void Start()
    {
        dzienteraz = System.DateTime.Now.ToString("dd");
        godzinyteraz = System.DateTime.Now.ToString("HH");
        minutyteraz = System.DateTime.Now.ToString("mm");
        czasoffline = int.Parse(dzienteraz) - int.Parse(dzien);
        czasoffline = czasoffline * 24;
        czasoffline = czasoffline + (int.Parse(godzinyteraz) - int.Parse(godziny));
        czasoffline = czasoffline * 60;
        czasoffline = czasoffline + (int.Parse(minutyteraz) - int.Parse(minuty));
        czasoffline += double.Parse(PlayerPrefs.GetString("CzasOffline"));
        PlayerPrefs.SetString("CzasOffline", czasoffline.ToString());
        if(czasoffline > 60)
        {
            czasoffline = 60;
        }
        if(czasoffline > 1 && PlayerPrefs.GetString("PoziomKopalni") != "")
        {
            przychodoffline = (czasoffline) * 6 * double.Parse(PlayerPrefs.GetString("Przychod"));
            if(PlayerPrefs.GetString("SumaOffline") != "")
            {
                sumaprzychoduoffline = double.Parse(PlayerPrefs.GetString("SumaOffline"));
            }
            else
            {
                sumaprzychoduoffline = 0;
            }
            
            sumaprzychoduoffline += przychodoffline;
            PlayerPrefs.SetString("SumaOffline", sumaprzychoduoffline.ToString());
        }

        if(czasoffline > 1 && PlayerPrefs.GetString("PoziomTartaku") != "")
        {
            przychodOfflineDrewno = (czasoffline) * 6 * double.Parse(PlayerPrefs.GetString("PrzychodDrewna"));
            if(PlayerPrefs.GetString("SumaOfflineDrewno") != "")
            {
                sumaprzychoduofflinedrewno = double.Parse(PlayerPrefs.GetString("SumaOfflineDrewno"));
            }
            else
            {
                sumaprzychoduofflinedrewno = 0;
            }
            sumaprzychoduofflinedrewno += przychodOfflineDrewno;
            PlayerPrefs.SetString("SumaOfflineDrewno", sumaprzychoduofflinedrewno.ToString());
        }

    }

    public void OpenOfflinePanel()
    {
        OfflinePanel.SetActive(true);
        OfflineTime.text = czasoffline.ToString() + "  min";
        OfflineKamien.text = sumaprzychoduoffline.ToString();
        OfflineDrewno.text = sumaprzychoduofflinedrewno.ToString();
    }

    public void CloseOfflinePanel()
    {
        OfflinePanel.SetActive(false);
    }

    public void Zbierz()
    {
        Zasoby.Stone += sumaprzychoduoffline;
        Zasoby.Wood += sumaprzychoduofflinedrewno;
        sumaprzychoduoffline = 0;
        sumaprzychoduofflinedrewno = 0;
        czasoffline = 0;
        PlayerPrefs.SetString("CzasOffline", czasoffline.ToString());
        OfflineKamien.text = sumaprzychoduoffline.ToString();
        OfflineDrewno.text = sumaprzychoduofflinedrewno.ToString();
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
        PlayerPrefs.SetString("SumaOffline", sumaprzychoduoffline.ToString());
        PlayerPrefs.SetString("SumaOfflineDrewno", sumaprzychoduofflinedrewno.ToString());

    }

    public void Zbierzx2()
    {
        Zasoby.Stone += sumaprzychoduoffline * 2;
        Zasoby.Wood += sumaprzychoduofflinedrewno * 2;
        sumaprzychoduoffline = 0;
        sumaprzychoduofflinedrewno = 0;
        czasoffline = 0;
        PlayerPrefs.SetString("CzasOffline", czasoffline.ToString());
        OfflineKamien.text = sumaprzychoduoffline.ToString();
        OfflineDrewno.text = sumaprzychoduofflinedrewno.ToString();
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
        PlayerPrefs.SetString("SumaOffline", sumaprzychoduoffline.ToString());
        PlayerPrefs.SetString("SumaOfflineDrewno", sumaprzychoduofflinedrewno.ToString());
    }




}
