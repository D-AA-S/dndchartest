﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollCharScript : MonoBehaviour
{
    //initialization of race and playerclass lists
    static private race[] raceOptions = new race[9];
    static private playerclass[] classoptions = new playerclass[12];
    static private int hpmods;
    static private int acmods;
    private int alignVal;
    private int charVal;
    private int raceVal;
    private Queue<int> rolledStats;
    private int randompoint;
    static private int abilityNum = 6;
    static private string[] alignmentoptions;

    public GameObject charAlign, charClass, charRace;
    public Text wsDis,hpDis,acDis; //Text windows that display the hp, walkspeed, ac values
    public Text strDis, dexDis, conDis, intDis, wisDis, chaDis; //Text windows that display the stat values


    //Adds all races & classes along with corresponding values for later usage
    public void initialization()
    {
        raceOptions[0] = new race() { name = "Dragonborn", walkspeed = 30};
        raceOptions[1] = new race() { name = "Dwarf", walkspeed = 25 };
        raceOptions[2] = new race() { name = "Elf", walkspeed = 30 };
        raceOptions[3] = new race() { name = "Gnome", walkspeed = 25 };
        raceOptions[4] = new race() { name = "Half-Elf", walkspeed = 30 };
        raceOptions[5] = new race() { name = "Half-Orc", walkspeed = 30 };
        raceOptions[6] = new race() { name = "Halfling", walkspeed = 25 };
        raceOptions[7] = new race() { name = "Human", walkspeed = 30 };
        raceOptions[8] = new race() { name = "Tiefling", walkspeed = 30 };

        classoptions[0] = new playerclass() { name = "Barbarian", hp = 12 };
        classoptions[1] = new playerclass() { name = "Paladin",  hp = 10 };
        classoptions[2] = new playerclass() { name = "Ranger",  hp = 10 };
        classoptions[3] = new playerclass() { name = "Fighter", hp = 10 };
        classoptions[4] = new playerclass() { name = "Bard",  hp = 8 };
        classoptions[5] = new playerclass() { name = "Cleric",  hp = 8 };
        classoptions[6] = new playerclass() { name = "Druid", hp = 8 };
        classoptions[7] = new playerclass() { name = "Monk",  hp = 8 };
        classoptions[8] = new playerclass() { name = "Rogue",  hp = 8 };
        classoptions[9] = new playerclass() { name = "Warlock", hp = 8 };
        classoptions[10] = new playerclass() { name = "Sorcerer", hp = 6 };
        classoptions[11] = new playerclass() { name = "Wizard", hp = 6 };
        alignmentoptions = new string[] {"Lawful Good","Lawful Neutral","Lawful Evil","Neutral Good"
            ,"True Neutral","Neutral Evil","Chaotic Good","Chaotic Neutral","Chaotic Evil"};
    }

    //find matching class & updates it's corresponding values
    public void characterclass()
    {
        charVal = charClass.GetComponent<Dropdown>().value;
        if (charVal != 0)
        {
            Pdat.instance.Pl.playerClass = classoptions[charVal-1].name;
            Pdat.instance.Pl.hp = classoptions[charVal-1].hp;
        }
        else
        {
            randompoint = Random.Range(0,11);
            Pdat.instance.Pl.playerClass = classoptions[randompoint].name;
            Pdat.instance.Pl.hp = classoptions[randompoint].hp;
            charClass.GetComponent<Dropdown>().value = ++randompoint;
        }
    }

    //find matching race & updates it's corrosponding values
    public void characterrace()
    {
        raceVal = charRace.GetComponent<Dropdown>().value;
        if (raceVal != 0)
        {
            Pdat.instance.Pl.race = raceOptions[raceVal-1].name;
            Pdat.instance.Pl.walkSpeed = raceOptions[raceVal-1].walkspeed;
            wsDis.GetComponent<Text>().text = raceOptions[raceVal-1].walkspeed.ToString();
        }
        else
        {
            randompoint = Random.Range(0,9);
            Pdat.instance.Pl.race = raceOptions[randompoint].name;
            Pdat.instance.Pl.walkSpeed = raceOptions[randompoint].walkspeed;
            wsDis.GetComponent<Text>().text = raceOptions[randompoint].walkspeed.ToString();
            charRace.GetComponent<Dropdown>().value = ++randompoint;
        }
    }

    //Detects namechanges and adds it to instance
    public void namechange()
    {
        Pdat.instance.Pl.characterName = GameObject.Find("Nameval").GetComponent<Text>().text;
    }

    //Same as namechange, except for alignment
    public void Alignment()
    {
        alignVal = charAlign.GetComponent<Dropdown>().value;
        if (alignVal != 0)
        {
            Pdat.instance.Pl.alignment = alignmentoptions[alignVal-1];
        }
        else
        {
            randompoint = Random.Range(0, 9);
            Pdat.instance.Pl.alignment = alignmentoptions[randompoint];
            charAlign.GetComponent<Dropdown>().value = randompoint;
        }
    }

    //Sorts rolls, totals the largest 2d6 & 2d4, to return total.
    public void statRoll(int diceNum)
    {
        for (int i = 0; i < abilityNum; i++)
        {
            //list to store rolls
            List<int> d6roll = new List<int>();

            int total;
            for (int j = 0; j < diceNum; j++)
            {
                d6roll.Add(Random.Range(1, 7));
            }
            d6roll.Sort();
            total = d6roll[diceNum-1] + d6roll[diceNum-2] + d6roll[diceNum-3]; //Gets the highest rolls from the bottom of the list & totals them
            rolledStats.Enqueue(total);
        }
    }


    public void statRoll()
    {
        List<int> dist = new List<int>();
        dist.Add(15);
        dist.Add(14);
        dist.Add(13);
        dist.Add(12);
        dist.Add(10);
        dist.Add(8);
        for (int i = 0; i < abilityNum; i++)
        {
            randompoint = Random.Range(0, dist.Count);
            rolledStats.Enqueue(dist[randompoint]);
            dist.RemoveAt(randompoint);
        }
    }


    public void statRolls()
    {
        rolledStats = new Queue<int>();
        rolledStats.Clear();
        switch (Pdat.instance.Pl.abilityChoice)
        {
            case 0:
                statRoll(4);
                break;
            case 1:
                statRoll(3);
                break;
            case 2:
                statRoll();
                break;
        }
        Pdat.instance.Pl.abilityStr = rolledStats.Dequeue();
        strDis.GetComponent<Text>().text = Pdat.instance.Pl.abilityStr.ToString();
        Pdat.instance.Pl.abilityDex = rolledStats.Dequeue();
        dexDis.GetComponent<Text>().text = Pdat.instance.Pl.abilityDex.ToString();
        Pdat.instance.Pl.abilityCon = rolledStats.Dequeue();
        conDis.GetComponent<Text>().text = Pdat.instance.Pl.abilityCon.ToString();
        Pdat.instance.Pl.abilityInt = rolledStats.Dequeue();
        intDis.GetComponent<Text>().text = Pdat.instance.Pl.abilityInt.ToString();
        Pdat.instance.Pl.abilityWis = rolledStats.Dequeue();
        wisDis.GetComponent<Text>().text = Pdat.instance.Pl.abilityWis.ToString();
        Pdat.instance.Pl.abilityCha = rolledStats.Dequeue();
        chaDis.GetComponent<Text>().text = Pdat.instance.Pl.abilityCha.ToString();
    }

    //Converts the PlayerData instance into a json file, then outputs it to a window
    public void generate()
    {
        characterclass();
        characterrace();
        statRolls();
        Alignment();
        hpCalc();
        acCalc();
    }

    public void reset()
    {
        Pdat.instance.Pl.clear();
        charAlign.GetComponent<Dropdown>().value = 0;
        charClass.GetComponent<Dropdown>().value = 0;
        charRace.GetComponent<Dropdown>().value = 0;
        wsDis.GetComponent<Text>().text = "";
        hpDis.GetComponent<Text>().text = "";
        acDis.GetComponent<Text>().text = "";
        strDis.GetComponent<Text>().text = "";
        dexDis.GetComponent<Text>().text = "";
        conDis.GetComponent<Text>().text = "";
        intDis.GetComponent<Text>().text = "";
        wisDis.GetComponent<Text>().text = "";
        chaDis.GetComponent<Text>().text = "";
    }

    public class race
    {
        public string name = "";
        public int walkspeed = 0;
    }
    public class playerclass
    {
        public string name = "";
        public int hp = 0;
    }

    public void acCalc()
    {
        int AC = 0;
        string pclass = Pdat.instance.Pl.playerClass;
        int dexmod = (int)Pdat.instance.Pl.abilityDex;

        if (pclass == "Barbarian")
        {
            int conmod = (int)Pdat.instance.Pl.abilityCon;
            AC = (10 + (((conmod - 10) / 2)) + ((dexmod - 10) / 2));
        }
        else if (pclass == "Monk")
        {
            int wismod = (int)Pdat.instance.Pl.abilityWis;
            AC = (10 + ((wismod - 10) / 2) + ((dexmod - 10) / 2));
        }
        else
            AC = (10 + ((dexmod - 10) / 2));
        Pdat.instance.Pl.armorClass = AC;
        acDis.GetComponent<Text>().text = AC.ToString();
    }

    public void hpCalc()
    {
        Pdat.instance.Pl.hp = (Pdat.instance.Pl.hp + (((int)Pdat.instance.Pl.abilityCon - 10) / 2));
        hpDis.GetComponent<Text>().text = Pdat.instance.Pl.hp.ToString();
    }
}
