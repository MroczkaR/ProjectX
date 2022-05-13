using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ErrorScript : MonoBehaviour
{

    public TMPro.TMP_Text texterroru;
    public GameObject errorPanel;

    public static string errortext;
    public static bool showErrorPanel = false;
    void Start()
    {
       // StartCoroutine(ErrorTimer());
        
    }

   public void OffErrorPanel()
   {
       errorPanel.SetActive(false);
   }

    private void Update()
    {
        if(showErrorPanel == true)
        {
            texterroru.text = errortext;
            errorPanel.SetActive(true);
            showErrorPanel = false;
        }
    }
  /* IEnumerator ErrorTimer()
   {
       yield return new WaitForSeconds(3);
       SceneManager.LoadScene(StartScript.aktscena);
       
   }*/
}
