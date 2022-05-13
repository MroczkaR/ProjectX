using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Walka : MonoBehaviour
{
   public TMPro.TMP_Text akthppostaciwalka;
   public TMPro.TMP_Text maxhppostaciwalka;
   public TMPro.TMP_Text akthppotworawalka;
   public TMPro.TMP_Text maxhppotworawalka;
   public TMPro.TMP_Text infobrpostaci;
   public TMPro.TMP_Text infoobrpotwora;
   public TMPro.TMP_Text poziompostaciwalka;
   public TMPro.TMP_Text aktexppostaciwalka;
   public TMPro.TMP_Text nazwapotwora;
   public TMPro.TMP_Text infoNazwaPotwora;
   public TMPro.TMP_Text infoElementarPotwora;
   public TMPro.TMP_Text infoHPPotwora;
   public TMPro.TMP_Text infoDmgPotwora;
   public TMPro.TMP_Text infoPancerzPotwora;
   public TMPro.TMP_Text infoKrytPotwora;
   public TMPro.TMP_Text infoUnikPotwora;
   public Button batak;
   public Slider HpBarPostac;
   public Slider HpBarPotwor;
   public Image ExpBar;
   public GameObject InfoMonsterPanel;

   int losobrpost;
   int losobrpotwora;
   int blocked = 0;
   int blocked2 = 0;
   public static bool skillOn = false;
   public static int akthppotwora;
   public static int maxhppotwora;
   public static int minobrpotwora;
   public static int maxobrpotwora;
   public static int obronapotwora;
   public static int szansanaunikpotwora;
   public static int szansanakrytpotwora;
   public static int elementarPotwora;
   int losowanieunikupotwora;
   int redukcjaobrazenpotwora;
   int szansaobnizeniaobrazenpostaci;
   int atakkrytpotwora;
   string czyKrytPostaci;
   int roundexp = 0;
    public static int xp;

    int redukcjaobrazen;
    int szansaobnizeniaobrazenpotwora;
    int losowanieuniku;
    int atakkrytpost;
    private void Start()
   {
       ActiveButtons(true);
       PlayerPrefs.SetInt("Walczone", 1);
      if(PlayerPrefs.GetInt("PoziomPostaci") != 0)
      {
          Dane.poziompost = PlayerPrefs.GetInt("PoziomPostaci");
          Dane.dostpktstat = PlayerPrefs.GetInt("DostPktPostaci");
          Dane.aktexppost = PlayerPrefs.GetInt("AktExpPostaci");
          Dane.maxexppost = PlayerPrefs.GetInt("MaxExpPostaci");
          Dane.akthppost = PlayerPrefs.GetInt("AktHpPostaci");
          Dane.maxhppost = PlayerPrefs.GetInt("MaxHpPostaci");
          Dane.obronapost = PlayerPrefs.GetInt("ObronaPostaci");
      }

              if(PlayerPrefs.GetInt("MinObrPostaci") != 0)
        {
            Dane.minobrpost = PlayerPrefs.GetInt("MinObrPostaci");
            Dane.maxobrpost = PlayerPrefs.GetInt("MaxObrPostaci");
        }
        if(Dane.maxhppost == 0)
        {
            Dane.maxhppost = 5;
        }
        akthppostaciwalka.text = Dane.akthppost.ToString();
        maxhppostaciwalka.text = Dane.maxhppost.ToString();
        aktexppostaciwalka.text = (((float)Dane.aktexppost / Dane.maxexppost) * 100).ToString() + "%";
        poziompostaciwalka.text = Dane.poziompost.ToString();
        HpBarPostac.value = (float)Dane.akthppost / Dane.maxhppost;
        ExpBar.fillAmount = (float)Dane.aktexppost / Dane.maxexppost;

      if(AdminScript.adminxp != 0)
      {
          xp = AdminScript.adminxp;
      }
      nazwapotwora.text = Monster.nazwa;
      akthppotworawalka.text = akthppotwora.ToString();
      maxhppotworawalka.text = maxhppotwora.ToString();
      roundexp = (int)(((float)Dane.aktexppost / Dane.maxexppost) * 10000);
      aktexppostaciwalka.text = ((float)roundexp / 100).ToString() + "%";
      HpBarPotwor.value = (float)akthppotwora / maxhppotwora;   
      
   }

   void Update()
   {


       if(infoobrpotwora.transform.position.y > 1400)
       {
           infoobrpotwora.transform.position = new Vector3(300, 1400, transform.position.z);
           infoobrpotwora.gameObject.SetActive(false);
           infoobrpotwora.text = "";
           infoobrpotwora.gameObject.SetActive(true);
       }
       if(infobrpostaci.transform.position.y > 1400)
       {
           infobrpostaci.transform.position = new Vector3(800, 1400, transform.position.z);
           infobrpostaci.gameObject.SetActive(false);
           infobrpostaci.text = "";
           infobrpostaci.gameObject.SetActive(true);
       }

       if(skillOn == true)
       {
            if(akthppotwora > 0)
        {
            StartCoroutine(AtakPotwora());
            skillOn = false;
        }
       }

   }

    public void Atak()
    {
        if(akthppotwora > 0 && Dane.akthppost > 0)
        {
            losobrpost = Random.Range(Dane.minobrpost, Dane.maxobrpost +1);
            redukcjaobrazenpotwora = obronapotwora / 10;
                losobrpost -= redukcjaobrazenpotwora;
                if(losobrpost <= redukcjaobrazenpotwora && losobrpost != 0)
                {
                    infobrpostaci.text = "Blok !";
                    blocked2 = 1;
                }
                else
                {
                    blocked2 = 0;
                }
                redukcjaobrazenpotwora = obronapotwora % 10;
                if(redukcjaobrazenpotwora != 0)
                {
                    szansaobnizeniaobrazenpostaci = Random.Range(1, 11);
                    if(szansaobnizeniaobrazenpostaci <= redukcjaobrazenpotwora)
                    {
                        losobrpost --;
                        if(losobrpost <= 0)
                        {
                            infobrpostaci.text = "Blok !";
                            blocked2 = 1;
                        }
                    }
                }
                
                if(losobrpost >= 0 && blocked2 == 0)
                {
                    losowanieunikupotwora = Random.Range(1, 101);
                    if(losowanieunikupotwora <= szansanaunikpotwora)
                    {
                        infobrpostaci.text = "Unik !";
                    }
                    else
                    {
                        atakkrytpost = Random.Range(1, 101);
                        if(atakkrytpost <= Dane.krytpost)
                        {
                            losobrpost = losobrpost * 2;
                            czyKrytPostaci = " *";
                        }
                        else
                        {
                            czyKrytPostaci = "";
                        }
                        akthppotwora -= losobrpost;
                        HpBarPotwor.value = (float)akthppotwora / maxhppotwora;
                        infobrpostaci.text = "-" + losobrpost.ToString() + czyKrytPostaci.ToString();
                    }
                    
                }
            //batak.transform.position = new Vector2 (x:360, y:340);
            if(akthppotwora <= 0)
            {
                infobrpostaci.text = "+"+ xp + " xp";
                Dane.aktexppost = Dane.aktexppost + xp;
                roundexp = (int)(((float)Dane.aktexppost / Dane.maxexppost) * 10000);
                aktexppostaciwalka.text = ((float)roundexp / 100).ToString() + "%";
                PlayerPrefs.SetInt("AktExpPostaci", Dane.aktexppost);
                ExpBar.fillAmount = (float)Dane.aktexppost / Dane.maxexppost;
                FightSkillPanel.CheckTimeSkill();
                
                if(Dane.aktexppost >= Dane.maxexppost)
                {
                    LevelUp();
                }
                StartCoroutine(RespPotwora());
                
                
               
            }  
              
            akthppotworawalka.text = akthppotwora.ToString();
            infobrpostaci.transform.position = new Vector3(800, 1300, transform.position.z);
        }
        if(akthppotwora > 0)
        {
            StartCoroutine(AtakPotwora());
        }

        ActiveButtons(false);
        
     
    }

    

    void LevelUp()
    {
        Dane.poziompost ++;
        Dane.dostpktstat += 2;
        Skills.pktMocy ++;
        poziompostaciwalka.text = Dane.poziompost.ToString();
        Dane.aktexppost = Dane.aktexppost - Dane.maxexppost;
        if(Dane.poziompost < 2)
        {
            Dane.maxexppost = 10;
        }
        else
        {
            Dane.maxexppost = Dane.maxexppost * 2 + Dane.maxexppost / 2;
            Dane.maxexppost -= Dane.maxexppost % 5;
        }
        
        aktexppostaciwalka.text = (((float)Dane.aktexppost / Dane.maxexppost) * 100).ToString() + "%";
        ExpBar.fillAmount = (float)Dane.aktexppost / Dane.maxexppost;
        //maxexppostaciwalka.text = Dane.maxexppost.ToString();
        PlayerPrefs.SetInt("PoziomPostaci", Dane.poziompost);
        PlayerPrefs.SetInt("DostPktPostaci", Dane.dostpktstat);
        PlayerPrefs.SetInt("AktExpPostaci", Dane.aktexppost);
        PlayerPrefs.SetInt("MaxExpPostaci", Dane.maxexppost);
        PlayerPrefs.SetInt("PktMocy", Skills.pktMocy);
    }

    IEnumerator RespPotwora()
    {
        yield return new WaitForSeconds(3);
        infobrpostaci.text = "";
        
        akthppotwora = maxhppotwora;
        akthppotworawalka.text = akthppotwora.ToString();
        maxhppotworawalka.text = maxhppotwora.ToString();
        HpBarPotwor.value = (float)akthppotwora / maxhppotwora;
        ActiveButtons(true);
    }

    IEnumerator AtakPotwora()
    {  
        yield return new WaitForSeconds(0.5f);
                losobrpotwora = Random.Range(minobrpotwora, maxobrpotwora+1);
                redukcjaobrazen = Dane.obronapost / 10;
                if(losobrpotwora <= redukcjaobrazen && losobrpotwora != 0)
                {
                    infoobrpotwora.text = "Blok !";
                    
                    blocked = 1; 
                }
                else
                {
                    blocked = 0;
                }
                losobrpotwora -= redukcjaobrazen;
                redukcjaobrazen = Dane.obronapost % 10;
                if(redukcjaobrazen != 0)
                {
                    szansaobnizeniaobrazenpotwora = Random.Range(1, 11);
                    if(szansaobnizeniaobrazenpotwora <= redukcjaobrazen)
                    {
                        losobrpotwora --;
                        if(losobrpotwora <= 0)
                        {
                            infoobrpotwora.text = "Blok !";
                           
                            blocked = 1;
                        }
                    }
                }
              
                if(losobrpotwora >= 0 && blocked == 0)
                {
                    losowanieuniku = Random.Range(1, 101);
                    if(losowanieuniku <= Dane.unikpost)
                    {
                        infoobrpotwora.text = "Unik !";
                    }
                    else
                    {
                        atakkrytpotwora = Random.Range(1, 101);
                        if(atakkrytpotwora <= szansanakrytpotwora)
                        {
                            losobrpotwora = losobrpotwora * 2;
                            infoobrpotwora.text = "-" + losobrpotwora.ToString() + " *";
                        }
                        else
                        {
                            infoobrpotwora.text = "-" + losobrpotwora.ToString();
                        }
                        Dane.akthppost -= losobrpotwora;
                        HpBarPostac.value = (float)Dane.akthppost / Dane.maxhppost;
                        
                        
                    }
                    
                }  
                akthppostaciwalka.text = Dane.akthppost.ToString();
                PlayerPrefs.SetInt("AktHpPostaci", Dane.akthppost);
                infoobrpotwora.transform.position = new Vector3(300, 1300, transform.position.z);
                FightSkillPanel.CheckTimeSkill();
                ActiveButtons(true);


             if(Dane.akthppost <= 0)
       {
               ErrorScript.errortext = "Przegrana !\n" + "Jesteś zbyt ciężko ranny\n" + "Udaj się domu, aby opatrzyć rany"; 
               ErrorScript.showErrorPanel = true;
               ActiveButtons(false);
               
           
       }
                StopCoroutine(AtakPotwora());
       
    }

    public void OpenInfoMonsterPanel()
    {
        InfoMonsterPanel.SetActive(true);
        infoNazwaPotwora.text = Monster.nazwa;
        infoHPPotwora.text = "HP :   " + maxhppotwora.ToString();
        infoDmgPotwora.text = "Obrażenia :   " + minobrpotwora.ToString() + "  -  " + maxobrpotwora.ToString();
        infoPancerzPotwora.text = "Pancerz :   " + obronapotwora.ToString();
        infoKrytPotwora.text = "Szansa na kryt. uderz. :   " + szansanakrytpotwora.ToString() + " %";
        infoUnikPotwora.text = "Szansa na unik :   " + szansanaunikpotwora.ToString() + " %";
        if(elementarPotwora == 1)
        {
            infoElementarPotwora.text = "WIATR";
        }
        else if(elementarPotwora == 2)
        {
            infoElementarPotwora.text = "ZIEMIA";
        }
        else if (elementarPotwora == 3)
        {
            infoElementarPotwora.text = "WODA";
        }
        else
        {
            infoElementarPotwora.text= "OGIEŃ";
        }
    }

    public void CloseInfoMP()
    {
        InfoMonsterPanel.SetActive(false);
    }

    void ActiveButtons(bool active)
    {
        batak.enabled = active;
        for(int i = 1; i < 6; i++)
        {
            Button Btn;
            Btn = GameObject.Find(i.ToString()).GetComponent<Button>();
            if(PlayerPrefs.GetInt("SqSlot" + i.ToString()) != 0)
            {
                Btn.enabled = active;
            }
            else
            {
                Btn.enabled = false;
            }

        }
    }

}
