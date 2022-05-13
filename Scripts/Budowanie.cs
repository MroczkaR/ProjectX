using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Budowanie : MonoBehaviour
{
    public TMPro.TMP_Text cowybudowac;
    public static string nazwabudynku;
    public static int kosztbudowykamien;
    public static int kosztbudowydrzewo;
    public TMPro.TMP_Text kosztkamien;
    public TMPro.TMP_Text kosztdrzewo;
    public GameObject BuildPanel;
    public static bool openBuildPanel = false;
 
   /* void Start()
    {
        cowybudowac.text = nazwabudynku;
        kosztkamien.text = kosztbudowykamien.ToString();
        kosztdrzewo.text = kosztbudowydrzewo.ToString();
    }*/
    
    private void Update()
    {
        if(openBuildPanel == true)
        {
            OpenBPanel();
        }
    }

    public void BudujTak()
    {
        if(Zasoby.Stone >= kosztbudowykamien)
        {
            if(Zasoby.Wood >= kosztbudowydrzewo)
        {
         
        if(StartScript.aktscena == 3)
        {      
            PlayerPrefs.SetInt("WybudowanaKopalnia", 1);
            SceneManager.LoadScene(3);
        }
        if(StartScript.aktscena == 4)
        {
            PlayerPrefs.SetInt("WybudowanyTartak", 1);
            SceneManager.LoadScene(4);
        }
        if(StartScript.aktscena == 11)
        {
            Zasoby.Stone -= kosztbudowykamien; 
            Zasoby.Wood -= kosztbudowydrzewo;      
            PlayerPrefs.SetInt("WybudowanyDom", 1);
            SceneManager.LoadScene(11);
        }
        if(StartScript.aktscena == 13)
        {
            Zasoby.Stone -= kosztbudowykamien;
            Zasoby.Wood -= kosztbudowydrzewo;
            PlayerPrefs.SetInt("WybudowanaHuta", 1);
            SceneManager.LoadScene(13);
        }
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
        }
        else
        {
            ErrorScript.errortext = "Masz za mało drewna !";
            ErrorScript.showErrorPanel = true;
        }
        }
        else
        {
            ErrorScript.errortext = "Masz za mało kamienia !";
            ErrorScript.showErrorPanel = true;
        }

        BuildPanel.SetActive(false);
    }

    public void BudujNie()
    {
       
            BuildPanel.SetActive(false);
        
    }

    void OpenBPanel()
    {
        cowybudowac.text = nazwabudynku;
        kosztkamien.text = kosztbudowykamien.ToString();
        kosztdrzewo.text = kosztbudowydrzewo.ToString();
        BuildPanel.SetActive(true);
        openBuildPanel = false;
    }

}
