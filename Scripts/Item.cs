using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static int WymaganyLv;
    public static int MinObr;
    public static int MaxObr;
    public static int Index;
    public static int Stopien;
    public static string Nazwa;
    public static int Pancerz;
    public static int Cena;

    public static void CheckItem(int Index)
    {
        if(Index == 1)
        {
            DrewnianyMiecz();
        }
        else if(Index == 101)
        {
            SkorzanaZbroja();
        }
        else if(Index == 201)
        {
            DrewnianyHelm();
        }
        else if(Index == 301)
        {
            DrewnianaTarcza();
        }
        else if(Index == 401)
        {
            SkorzaneButy();
        }
    }

    public static void DrewnianyMiecz()
    {
        Nazwa = "Drewniany Miecz";
        Stopien = 1;
        Index = 1;
        WymaganyLv = 1;
        MinObr = 1;
        MaxObr = 3;
        Pancerz = 0;
        Cena = 2;
    }

    public static void KamiennyMiecz()
    {
        Nazwa = "Kamienny Miecz";
        Stopien = 1;
        Index = 2;
        WymaganyLv = 3;
        MinObr = 3;
        MaxObr = 7;
        Cena = 300;
    }

    public static void SkorzanaZbroja()
    {
        Nazwa = "Skórzana Zbroja";
        Stopien = 1;
        Index = 101;
        WymaganyLv = 2;
        MinObr = 0;
        MaxObr = 0;
        Pancerz = 5;
        Cena = 5;
    }

    public static void DrewnianyHelm()
    {
        Nazwa = "Drewniany Hełm";
        Stopien = 1;
        Index = 201;
        WymaganyLv = 3;
        MinObr = 0;
        MaxObr = 0;
        Pancerz = 3;
        Cena = 3;
    }

    public static void DrewnianaTarcza()
    {
        Nazwa = "Drewniana Tarcza";
        Stopien = 1;
        Index = 301;
        WymaganyLv = 4;
        MinObr = 0;
        MaxObr = 0;
        Pancerz = 4;
        Cena = 3;
    }

    public static void SkorzaneButy()
    {
        Nazwa = "Skórzane Buty";
        Stopien = 1;
        Index = 401;
        WymaganyLv = 5;
        MinObr = 0;
        MaxObr = 0;
        Pancerz = 2;
        Cena = 1;
    }
}
