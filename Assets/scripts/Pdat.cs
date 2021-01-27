using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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
        public string playerName;
        public string race;
        public string playerClass;
        public string alignment;

        //substats
        public int hp;
        public int armorClass;
        public int walkSpeed;
        public int raceAge;
        public int charAge;

        public int abilityChoice;
        private string outputSentence;
        private string fileName;


        public void clear()
        {
            abilityStr = 0;
            abilityDex = 0;
            abilityCon = 0;
            abilityInt = 0;
            abilityWis = 0;
            abilityCha = 0;
            playerName = "";
            race = "";
            playerClass = "";
            alignment = "";
            hp = 0;
            armorClass = 0;
            walkSpeed = 0;
            raceAge = 0;
            outputSentence = "";
            fileName = "";
        }

        public string description(string eyeCol, string scaleCol, string skinCol)
        {
            string sentence = "";
            charAge = UnityEngine.Random.Range(15, raceAge);
            if (race == "Dragonborn")
            {
                sentence = String.Format("{0:Name} is a {1:Age} year old {2:Race} {3:} \nThey have" +
                    " {4:Color} eyes and {5:Color} scales", playerName, charAge, race, playerClass, eyeCol, scaleCol);
            }
            else
            {
                sentence = String.Format("{0:Name} is a {1:Age} year old {2:Race} {3:} \nThey have" +
                    " {4:Color} eyes and {5:Color} skin", playerName, charAge, race, playerClass, eyeCol, skinCol);
            }
            outputSentence = sentence;
            fileName = String.Format("{0:Name}{1:Age}{2:Race}",playerName,charAge,race);
            return sentence;
        }

        public void outputAFile()
        {
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
