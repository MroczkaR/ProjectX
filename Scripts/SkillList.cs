using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    public static void CheckSkill(int x)
    {
        int lv = PlayerPrefs.GetInt("SkillLevel" + x.ToString());
        if(x == 1)
        {
            ZaczarowanyWiatr(lv);
        }
        else if(x == 2)
        {
            CierniowaZbroja(lv);
        }
        else if(x == 3)
        {
            LodowaSciezka(lv);
        }
        else if(x == 4)
        {
            OgnistyMiecz(lv);
        }

    }

static int ObliczBonus(int lv, int x, int y)
{
	if(lv == 0 || lv == 1)
{
	return 1;
}
else
{
	return (ObliczBonus(lv-1, x, y) + 1) * x/y;
}

/*int bonus = 1;

	for(int i = 0; i <= lv ; i ++)
	{
		x = x * x;
		y = y * y;
	}
return bonus * x/y;*/
}

public static void ZaczarowanyWiatr (int lvSkilla)
{
	Skills.nazwaSkilla = "Zaczarowany Wiatr";
	Skills.indexSkilla = 1;
	Skills.poziomSkilla = lvSkilla;
	Skills.typeDmg = 1;
	Skills.czasTrwania = 0;
	Skills.czasOczekiwania = 3 + (lvSkilla / 5);
	Skills.bonus1 = ObliczBonus(lvSkilla, 12, 10);
	Skills.bonus2 = lvSkilla * 2;
	Skills.bonus3 = 0;
	Skills.textbonusu1 = "Obrażenia : " + Skills.bonus1.ToString();
	Skills.textbonusu2 = "Szansa na Antymagię : " + Skills.bonus2.ToString() + "%";
	Skills.textbonusu3 = "";
	FightSkillPanel.ZadaneObrazenia = Skills.bonus1;
	FightSkillPanel.Antymagia = Skills.bonus2;
	
}

public static void CierniowaZbroja (int lvSkilla)
{
	Skills.nazwaSkilla = "Cierniowa Zbroja";
	Skills.indexSkilla = 2;
	Skills.poziomSkilla = lvSkilla;
	Skills.typeDeff = 2;
	Skills.czasTrwania = 2 + (lvSkilla / 3);
	Skills.czasOczekiwania = 2 + (lvSkilla / 5);
	Skills.bonus1 = ObliczBonus(lvSkilla, 15, 10);
	Skills.bonus2 = ObliczBonus(lvSkilla, 8, 10);
	Skills.bonus3 = 0;
	Skills.textbonusu1 = "Obrona : " + Skills.bonus1.ToString();
	Skills.textbonusu2 = "Szansa na odbicie ciosu : " + Skills.bonus2.ToString() + "%";
	Skills.textbonusu3 = "";
	FightSkillPanel.Obrona = Skills.bonus1;
	FightSkillPanel.OdbicieCiosu = Skills.bonus2;
	
}

public static void LodowaSciezka (int lvSkilla)
{
	Skills.nazwaSkilla = "Lodowa ścieżka";
	Skills.indexSkilla = 3;
	Skills.poziomSkilla = lvSkilla;
	Skills.czasTrwania = 3 + (lvSkilla / 3);
	Skills.czasOczekiwania = 3 + (lvSkilla / 4);
	Skills.bonus1 = 0;
	Skills.bonus2 = 0;
	Skills.bonus3 = 0;
	Skills.textbonusu1 = "Szansa na unik : -" + Skills.bonus1.ToString() + "%";
	Skills.textbonusu2 = "Otrzymywane obrażenia : +" + Skills.bonus2.ToString() + "%";
	Skills.textbonusu3 = "";
	/*FightSkillPanel.SzansaNaUnik = Skills.bonus1;
	FightSkillPanel. = Skills.bonus2;
	FightSkillPanel. = Skills.bonus3;*/
	
}



    public static void OgnistyMiecz(int lvSkilla)
{
    Skills.nazwaSkilla = "Ognisty Miecz";
    Skills.indexSkilla = 4;
    Skills.poziomSkilla = lvSkilla;
    Skills.typeDmg = 4;
    Skills.czasTrwania = 2 + lvSkilla + (Dane.moc / 10);
	Skills.czasOczekiwania = 1 + lvSkilla / 3;
    Skills.bonus1 = ObliczBonus(lvSkilla, 15, 10);   //lvSkilla * 12/10 + (lvSkilla * Dane.moc * Dane.poziompost) / 10;  
    Skills.bonus2 = ObliczBonus(lvSkilla, 11, 10);   
    Skills.bonus3 = 0; 
    Skills.textbonusu1 = "Obrażenia : " + Skills.bonus1.ToString();
    Skills.textbonusu2 = "Szansa na podpalenie : " + Skills.bonus2.ToString() + "%";
    Skills.textbonusu3 = "";
    FightSkillPanel.Obrazenia = Skills.bonus1;
    FightSkillPanel.Podpalenie = Skills.bonus2;
}
}
