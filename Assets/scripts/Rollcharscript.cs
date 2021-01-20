using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollCharScript : MonoBehaviour
{
    //initialization of race and playerclass lists
    static private race[] raceOptions = new race[9];
    static private playerclass[] classoptions = new playerclass[12];
    static private string[] skinColor,Haircolor;
    static private string[] alignmentoptions;
    private int alignVal, charVal, raceVal;
    private int randompoint;
    private Queue<int> rolledStats;
    static private int abilityNum = 6;
    private string nameVal;
    private string[] names;

    public GameObject charAlign, charClass, charRace, charName;
    public Text wsDis,hpDis,acDis; //Text windows that display the hp, walkspeed, ac values
    public Text strDis, dexDis, conDis, intDis, wisDis, chaDis; //Text windows that display the stat values
    public TextAsset nameFile;


    //Adds all races & classes along with corresponding values for later usage
    private void Start()
    {
        names = nameFile.text.Split('\n');
        raceOptions[0] = new race() { name = "Dragonborn", walkspeed = 30, upperAge = 80};
        raceOptions[1] = new race() { name = "Dwarf", walkspeed = 25, upperAge = 350};
        raceOptions[2] = new race() { name = "Elf", walkspeed = 30, upperAge = 750};
        raceOptions[3] = new race() { name = "Gnome", walkspeed = 25, upperAge = 500};
        raceOptions[4] = new race() { name = "Half-Elf", walkspeed = 30, upperAge = 200};
        raceOptions[5] = new race() { name = "Half-Orc", walkspeed = 30, upperAge = 80};
        raceOptions[6] = new race() { name = "Halfling", walkspeed = 25, upperAge = 150};
        raceOptions[7] = new race() { name = "Human", walkspeed = 30, upperAge = 100};
        raceOptions[8] = new race() { name = "Tiefling", walkspeed = 30, upperAge = 120};

        classoptions[0] = new playerclass() { name = "Barbarian", hp = 12 };
        classoptions[1] = new playerclass() { name = "Paladin", hp = 10 };
        classoptions[2] = new playerclass() { name = "Ranger", hp = 10 };
        classoptions[3] = new playerclass() { name = "Fighter", hp = 10 };
        classoptions[4] = new playerclass() { name = "Bard", hp = 8 };
        classoptions[5] = new playerclass() { name = "Cleric", hp = 8 };
        classoptions[6] = new playerclass() { name = "Druid", hp = 8 };
        classoptions[7] = new playerclass() { name = "Monk", hp = 8 };
        classoptions[8] = new playerclass() { name = "Rogue", hp = 8 };
        classoptions[9] = new playerclass() { name = "Warlock", hp = 8 };
        classoptions[10] = new playerclass() { name = "Sorcerer", hp = 6 };
        classoptions[11] = new playerclass() { name = "Wizard", hp = 6 };
        alignmentoptions = new string[] {"Lawful Good","Lawful Neutral","Lawful Evil","N" +
            "eutral Good","True Neutral","Neutral Evil","Chaotic Good","Chaotic Neutral"
            ,"Chaotic Evil"};
    }

    //find matching class & updates it's corresponding values
    public void characterclass()
    {
        charVal = charClass.GetComponent<Dropdown>().value;
        if (charVal != 0 && charVal != 1)
        {
            Pdat.Inst.Pl.playerClass = classoptions[charVal - 1].name;
            Pdat.Inst.Pl.hp = classoptions[charVal - 1].hp;
        }
        else if (charVal == 1)
        {
            Pdat.Inst.Pl.noClass = true;
        }
        else
        {
            randompoint = Random.Range(0, 11);
            Pdat.Inst.Pl.playerClass = classoptions[randompoint].name;
            Pdat.Inst.Pl.hp = classoptions[randompoint].hp;
            charClass.GetComponent<Dropdown>().value = ++randompoint;
        }
    }

    //find matching race & updates it's corrosponding values
    public void characterrace()
    {
        raceVal = charRace.GetComponent<Dropdown>().value;
        if (raceVal != 0)
        {
            Pdat.Inst.Pl.race = raceOptions[raceVal - 1].name;
            Pdat.Inst.Pl.walkSpeed = raceOptions[raceVal - 1].walkspeed;
            Pdat.Inst.Pl.raceAge = raceOptions[raceVal - 1].upperAge;
            wsDis.GetComponent<Text>().text = raceOptions[raceVal - 1].walkspeed.ToString();
        }
        else
        {
            randompoint = Random.Range(0, 9);
            Pdat.Inst.Pl.race = raceOptions[randompoint].name;
            Pdat.Inst.Pl.walkSpeed = raceOptions[randompoint].walkspeed;
            Pdat.Inst.Pl.raceAge = raceOptions[randompoint].upperAge;
            wsDis.GetComponent<Text>().text = raceOptions[randompoint].walkspeed.ToString();
            charRace.GetComponent<Dropdown>().value = randompoint+1;
        }
    }

    //Detects namechanges and adds it to instance
    public void nameGen()
    {
        nameVal = charName.GetComponent<InputField>().text;
        if (nameVal == "")
        {
            nameVal = names[Random.Range(0, names.Length-1)];
            Pdat.Inst.Pl.playerName = nameVal;
            charName.GetComponent<InputField>().text = nameVal;
        }
        else
        {
            Pdat.Inst.Pl.playerName = nameVal;
        }
    }

    //Same as namechange, except for alignment
    public void Alignment()
    {
        alignVal = charAlign.GetComponent<Dropdown>().value;
        if (alignVal != 0)
        {
            Pdat.Inst.Pl.alignment = alignmentoptions[alignVal-1];
        }
        else
        {
            randompoint = Random.Range(0, 9);
            Pdat.Inst.Pl.alignment = alignmentoptions[randompoint];
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
        switch (Pdat.Inst.Pl.abilityChoice)
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
        Pdat.Inst.Pl.abilityStr = rolledStats.Dequeue();
        strDis.GetComponent<Text>().text = Pdat.Inst.Pl.abilityStr.ToString();
        Pdat.Inst.Pl.abilityDex = rolledStats.Dequeue();
        dexDis.GetComponent<Text>().text = Pdat.Inst.Pl.abilityDex.ToString();
        Pdat.Inst.Pl.abilityCon = rolledStats.Dequeue();
        conDis.GetComponent<Text>().text = Pdat.Inst.Pl.abilityCon.ToString();
        Pdat.Inst.Pl.abilityInt = rolledStats.Dequeue();
        intDis.GetComponent<Text>().text = Pdat.Inst.Pl.abilityInt.ToString();
        Pdat.Inst.Pl.abilityWis = rolledStats.Dequeue();
        wisDis.GetComponent<Text>().text = Pdat.Inst.Pl.abilityWis.ToString();
        Pdat.Inst.Pl.abilityCha = rolledStats.Dequeue();
        chaDis.GetComponent<Text>().text = Pdat.Inst.Pl.abilityCha.ToString();
    }

    public void sentenceGenrate()
    {
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
        nameGen();
        sentenceGenrate();
    }

    public void reset()
    {
        Pdat.Inst.Pl.clear();
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
        charName.GetComponent<InputField>().text = "";
    }

    public class race
    {
        public string name = "";
        public int walkspeed = 0;
        public int upperAge = 0;
    }
    public class playerclass
    {
        public string name = "";
        public int hp = 0;
    }

    public void acCalc()
    {
        int AC = 0;
        string pclass = Pdat.Inst.Pl.playerClass;
        int dexmod = (int)Pdat.Inst.Pl.abilityDex;

        if (pclass == "Barbarian")
        {
            int conmod = (int)Pdat.Inst.Pl.abilityCon;
            AC = (10 + (((conmod - 10) / 2)) + ((dexmod - 10) / 2));
        }
        else if (pclass == "Monk")
        {
            int wismod = (int)Pdat.Inst.Pl.abilityWis;
            AC = (10 + ((wismod - 10) / 2) + ((dexmod - 10) / 2));
        }
        else
            AC = (10 + ((dexmod - 10) / 2));
        Pdat.Inst.Pl.armorClass = AC;
        acDis.GetComponent<Text>().text = AC.ToString();
    }

    public void hpCalc()
    {
        Pdat.Inst.Pl.hp = (Pdat.Inst.Pl.hp + (((int)Pdat.Inst.Pl.abilityCon - 10) / 2));
        hpDis.GetComponent<Text>().text = Pdat.Inst.Pl.hp.ToString();
    }
}
