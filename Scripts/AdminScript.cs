using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AdminScript : MonoBehaviour
{
    public static int adminxp = 0;

    public void AddExp()
    {
        if(adminxp == 0)
        {
            adminxp = 5;
        }
        else
        {
            adminxp += 5;
        }
    }
    public void AddStone()
    {
        Zasoby.Stone += 1000;
        Zasoby.Wood += 1000;
        PlayerPrefs.SetString("Stone", Zasoby.Stone.ToString());
        PlayerPrefs.SetString("Wood", Zasoby.Wood.ToString());
    }

    public void AddStoneCoin()
    {
        Zasoby.OldCoin += 100;
        PlayerPrefs.SetString("OldCoins", Zasoby.OldCoin.ToString());
    }

    public void AddArmour()
    {
        Dane.obronapost += 5;
        PlayerPrefs.SetInt("ObronaPostaci", Dane.obronapost);
    }

    public void AddPower()
    {
        Skills.pktMocy ++;
        PlayerPrefs.SetInt("PktMocy", Skills.pktMocy);
    }

}
