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
                    " {4:Color} eyes and {5:Color} scales", playerName, charAge.ToString(), race, playerClass, eyeCol, scaleCol);
            }
            else
            {
                sentence = String.Format("{0:Name} is a {1:Age} year old {2:Race} {3:}\nThey have" +
                    " {4:Color} eyes and {5:Color} skin", playerName, charAge.ToString(), race, playerClass, eyeCol, skinCol);
            }
            outputSentence = sentence;
            fileName = playerName + charAge + race + ".txt";
            return sentence;
        }

        public void outputAFile()
        {
            File.WriteAllBytes(Application.dataPath.Replace("Assets", "DownloadedSheets/" + fileName), 
                System.Text.Encoding.UTF8.GetBytes(String.Format("{0:Name}\n{1:Race}    {2:Class}" +
                "\nStr: {3}  Dex: {4}  Con: {5}  Int: {6}  Wis: {7}  Cha:  {8}" +
                "\nHeath Points: {9}  Armour Class {10}  Walking Speed: {11}",
                playerName, race, playerClass, abilityStr.ToString(), abilityDex.ToString(), abilityCon.ToString(),
                abilityInt.ToString(), abilityWis.ToString(), abilityCha.ToString(), hp.ToString(), armorClass.ToString(), 
                walkSpeed.ToString() + "\n" + outputSentence)));
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
