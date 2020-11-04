using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pdat : MonoBehaviour
{
    [Serializable]
    public class Pstat
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
        public int maxhp, currenthp, hpdie;
        public int Armourclass;
        public int walkspeed, runspeed, jumpheight;


        //inventory
        public List<String> Inventory;
    }

    public static Pdat instance;
    public Pstat Pl;

    //singltion pattern
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            Pl = new Pstat();
        }
    }
}
