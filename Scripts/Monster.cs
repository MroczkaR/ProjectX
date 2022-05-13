using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static string nazwa;

    public void Wiwor()
    {
        nazwa = "Wiwor";
        Walka.xp = 1;
        Walka.elementarPotwora = 1;
        Walka.akthppotwora = 5;
        Walka.maxhppotwora = 5;
        Walka.minobrpotwora = 0;
        Walka.maxobrpotwora = 1;
        Walka.obronapotwora = 2;
        Walka.szansanakrytpotwora = 1;
        Walka.szansanaunikpotwora = 1;
        
        
    }

    public void Zaxac()
    {
        nazwa = "Zaxac";
        Walka.xp = 3;
        Walka.elementarPotwora = 1;
        Walka.akthppotwora = 10;
        Walka.maxhppotwora = 10;
        Walka.minobrpotwora = 1;
        Walka.maxobrpotwora = 2;
        Walka.obronapotwora = 4;
        Walka.szansanakrytpotwora = 2;
        Walka.szansanaunikpotwora = 2;
    }
}
