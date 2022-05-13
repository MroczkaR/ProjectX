using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OfflineScene : MonoBehaviour
{
    public TMPro.TMP_Text przychodoffline;
    void Start()
    {
        przychodoffline.text = Offline.przychodoffline.ToString();
        PlayerPrefs.SetString("dzien", System.DateTime.Now.ToString("dd"));
        PlayerPrefs.SetString("godziny", System.DateTime.Now.ToString("HH"));
        PlayerPrefs.SetString("minuty", System.DateTime.Now.ToString("mm"));
    }

    public void Zbierzx2()
    {
        Zasoby.Stone += (Offline.przychodoffline * 2);
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        SceneManager.LoadScene(0);
        
    }

    public void Zbierz()
    {
        Zasoby.Stone += Offline.przychodoffline;
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        SceneManager.LoadScene(0);
    }

    
}
