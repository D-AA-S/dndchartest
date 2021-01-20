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
        public int raceAge;

        public int abilityChoice;
        public bool noClass;

        public void clear()
        {
            abilityStr = 0;
            abilityDex = 0;
            abilityCon = 0;
            abilityInt = 0;
            abilityWis = 0;
            abilityCha = 0;
            characterName = "";
            race = "";
            playerClass = "";
            alignment = "";
            hp = 0;
            armorClass = 0;
            walkSpeed = 0;
        }
    }

    public static Pdat Inst;
    public Pstat Pl;


    //singltion pattern
    public void Awake()
    {
        if (Inst != null && Inst != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Inst = this;
            Pl = new Pstat();
        }
    }
}
