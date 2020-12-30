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
        public float abilityStr;
        public float abilityDex;
        public float abilityCon;
        public float abilityInt;
        public float abilityWis;
        public float abilityCha;

        //character choices
        public string characterName;
        public string race;
        public string playerClass;
        public string alignment;

        //substats
        public int hp;
        public int armorClass;
        public int walkSpeed;


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
