using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightSkillPanel : MonoBehaviour
{
    public static TMPro.TMP_Text Timer;
    public Button SkillBtn;
    static Button SkillBtnSt;
    public static int Obrazenia;
    public static int Obrona;
    public static int Podpalenie;
    public static int ZadaneObrazenia;
    public static int Antymagia;
    public static int OdbicieCiosu;
    public static int [] TimeLeft = new int [6];
    int BtnId;

    void Start()
    {
        for(int i = 1; i < 6; i++)
        {
            SkillBtn = GameObject.Find(i.ToString()).GetComponent<Button>();
            if(PlayerPrefs.GetInt("SqSlot"+ i.ToString()) != 0)
            {

                SkillBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("SqId" + PlayerPrefs.GetInt("SqSlot" + i.ToString()));
            }
            else
            {
                SkillBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("SqId0");
            }
        }

    }

    public void ActiveSkill(Button Btn)
    {
        SkillBtn = Btn;
        BtnId = PlayerPrefs.GetInt("SqSlot" + Btn.name);
        SkillList.CheckSkill(BtnId);

        TimeLeft[int.Parse(Btn.name)] = Skills.czasTrwania;
        Timer = GameObject.Find("Timer" + Btn.name).GetComponent<TMPro.TMP_Text>();
        Timer.text = Skills.czasTrwania.ToString();
        Walka.skillOn = true;
        SkillBtn.enabled = false;
        Debug.Log("Skill " + BtnId + " activated !");

    }

    public static void CheckTimeSkill()
    {
        for(int i = 1; i < 6; i++)
        {
            if(TimeLeft[i] > 0)
            {
                TimeLeft[i] --;

                Timer = GameObject.Find("Timer" + i.ToString()).GetComponent<TMPro.TMP_Text>();
                Timer.text = TimeLeft[i].ToString();
                if(TimeLeft[i] == 0)
                {
                    TurnOffSkill(i);
                }
            }

        }
    }

    public static void TurnOffSkill(int SkillId)
    {
        SkillId = PlayerPrefs.GetInt("SqSlot" + SkillId);
        SkillList.CheckSkill(SkillId);
        Dane.minobrpost -= Obrazenia;
        Dane.maxobrpost -= Obrazenia;
        Timer = GameObject.Find("Timer" + SkillId.ToString()).GetComponent<TMPro.TMP_Text>();
        Timer.text = "";
        SkillBtnSt = GameObject.Find(SkillId.ToString()).GetComponent<Button>();
        SkillBtnSt.enabled = true;
        Debug.Log("Skill " + SkillId + " disactivated !");
    }

    void DodajBonusy()
    {
        Dane.minobrpost += Obrazenia;
        Dane.maxobrpost += Obrazenia;
    }

      /*  public void OpenSkillPanel()
{
    SkillPanel.SetActive(true);
    SkillList.CheckSkill(BtnId);
    TNazwaSkilla.text = Skills.nazwaSkilla;
    TPoziomSkilla.text = "Poziom : " + Skills.poziomSkilla.ToString();
    TBonus1.text = Skills.textbonusu1;
    TBonus2.text = Skills.textbonusu2;
    TBonus3.text = Skills.textbonusu3;



    Timer1 = GameObject.Find("Timer2").GetComponent<TMPro.TMP_Text>(); *****************
}*/

}
