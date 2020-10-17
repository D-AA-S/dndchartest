using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour
{
    [Serializable]
    public class playerinfo
    {
        //Ability scores
        public float ability_str;
        public float ability_dex;
        public float ability_con;
        public float ability_int;
        public float ability_wis;
        public float ability_cha;

        //character choices
        public string character_name;
        public string race;
        public string playerclass;
        public string alignment;

        //substats
        public int maxxp, currentxp;
        public int maxhp, currenthp;
        public int Armourclass;
        public int walkspeed, runspeed, jumpheight;

        //inventory
        public List<String> Inventory; 
    }
}
