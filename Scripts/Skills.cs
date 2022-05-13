using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skills : MonoBehaviour
{
    public GameObject SkillPanel;
    public TMPro.TMP_Text TNazwaSkilla;
    public TMPro.TMP_Text TPoziomSkilla;
    public TMPro.TMP_Text TBonus1;
    public TMPro.TMP_Text TBonus2;
    public TMPro.TMP_Text TBonus3;
    public TMPro.TMP_Text TPktMocy;
    public TMPro.TMP_Text TKosztSkilla;
    public TMPro.TMP_Text TOldCoins;
    public Button Skill;
    public Button SkillPanelButton;
    int [] SkillePanelu = new int [6];
    public static string nazwaSkilla;
    public static int indexSkilla;
    public static int poziomSkilla = 0;
    public static int typeDmg;
    public static int typeDeff;
    public static string textbonusu1;
    public static int bonus1;
    public static string textbonusu2;
    public static int bonus2;
    public static string textbonusu3;
    public static int bonus3;
    public static int pktMocy;
    public static int kosztSkilla;
    public static int czasTrwania;
    public static int czasOczekiwania;
    bool duplicats = false;

    void Start()
    {
        pktMocy = PlayerPrefs.GetInt("PktMocy");
        TPktMocy.text = "Punkty mocy :  " + pktMocy.ToString();
        //Skill.GetComponent<Image>().sprite = Resources.Load<Sprite>("SqId-1");

        AddSkillImage();
        ChangeSkillImage();
        
    }

    public void BtnTest(Button Btn)
    {
        Skill = Btn;
        indexSkilla = int.Parse(Btn.name);
    }

    void AddSkillImage()
    {
            for(int i=1; i<6; i++)
        {
            SkillePanelu[i] = PlayerPrefs.GetInt("SqSlot" + i.ToString());
            SkillPanelButton = GameObject.Find("SKILL" + i.ToString()).GetComponent<Button>();
            if(SkillePanelu[i] != 0)
            {
                SkillPanelButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("SqId" + SkillePanelu[i].ToString());
                Colors.CheckSkillColor(i);
                SkillPanelButton.GetComponent<Image>().color = Colors.ActualColor;

            }
        }
    }

    void ChangeSkillImage()
    {
            for(int i=1; i<5; i++)
        {
            Skill = GameObject.Find(i.ToString()).GetComponent<Button>();
            if(PlayerPrefs.GetInt("SkillLevel" + i.ToString()) == 0)
            {
                Skill.GetComponent<Image>().sprite = Resources.Load<Sprite>("SqId-" + i.ToString());
                Colors.CheckSkillColor(i * (-1));
                Skill.GetComponent<Image>().color = Colors.ActualColor;
            }
            else
            {
                Skill.GetComponent<Image>().sprite = Resources.Load<Sprite>("SqId" + i.ToString());
                Colors.CheckSkillColor(i);
                Skill.GetComponent<Image>().color = Colors.ActualColor;
            }
        }
    }
    

    public void OpenSkillPanel()
{
    SkillPanel.SetActive(true);
    SkillList.CheckSkill(indexSkilla);
    kosztSkilla = poziomSkilla *12/10 + 1;
    TNazwaSkilla.text = nazwaSkilla;
    TKosztSkilla.text = kosztSkilla.ToString();
    TPoziomSkilla.text = "Poziom : " + poziomSkilla.ToString();
    TBonus1.text = textbonusu1;
    TBonus2.text = textbonusu2;
    TBonus3.text = textbonusu3;
}

public void CloseSkillPanel()
{
    SkillPanel.SetActive(false);
}

public void UlepszSkill()
{
    if(pktMocy > 0)
    {
        if(kosztSkilla <= Zasoby.OldCoin)
    {
            poziomSkilla ++;
            pktMocy --;
            Zasoby.OldCoin -= kosztSkilla;
            TOldCoins.text = Zasoby.OldCoin.ToString();
            TPktMocy.text = "Punkty mocy :  " + pktMocy.ToString();
            PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
            PlayerPrefs.SetInt("SkillLevel" + indexSkilla.ToString(), poziomSkilla);
            SkillList.CheckSkill(indexSkilla);
            OpenSkillPanel();
            ChangeSkillImage();

        //PlayerPrefs.SetInt("SqSlot1", 1);
        //AddSkillImage();
    }
    else
    {
        ErrorScript.errortext = "Nie wystarczajaca ilosc monet !";
        ErrorScript.showErrorPanel = true;
    }
    }
    else
    {
        ErrorScript.errortext = "Brak punktow mocy !";
        ErrorScript.showErrorPanel = true;
    }

}

public void AddSkill()
{
    for(int i=1; i<6; i++)
    {
        if(poziomSkilla > 0)
        {
            if(PlayerPrefs.GetInt("SqSlot" + i.ToString()) == 0)
        {
            duplicats = false;
            for(int k=1; k<6; k++)
            {
                if(PlayerPrefs.GetInt("SqSlot" + k.ToString()) == indexSkilla)
                {
                    duplicats = true;
                }
            }
            if(duplicats == false)
            {
                PlayerPrefs.SetInt("SqSlot" + i.ToString(), indexSkilla);
                AddSkillImage();
            }

        }
        }
        else
        {
            ErrorScript.errortext = "Najpierw ulepsz Skilla !";
            ErrorScript.showErrorPanel= true; 
        }
    }
}

public static void OgnistyMiecz(int lvSkilla)
{
    nazwaSkilla = "Ognisty Miecz";
    indexSkilla = 1;
    poziomSkilla = lvSkilla;
    bonus1 = lvSkilla * 12/10;
    textbonusu1 = "Obrażenia : " + bonus1.ToString(); 
    bonus2 = lvSkilla * 11/10; 
    textbonusu2 = "Szansa na podpalenie : " + bonus2.ToString() + "%";
    bonus3 = 0;
    textbonusu3 = "";

}

}


