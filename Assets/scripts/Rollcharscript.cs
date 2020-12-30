using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollCharScript : MonoBehaviour
{
    //initialization of race and playerclass lists
    static public List<race> races = new List<race>();
    static public List<playerclass> classplay = new List<playerclass>();
    static public int hpmods;
    static public int acmods;



    //Adds all races & classes along with corresponding values for later usage
    public void initialization()
    {
        races.Add(new race() { name = "Character's  Race?", walkspeed = 0});
        races.Add(new race() { name = "Dragonborn", walkspeed = 30});
        races.Add(new race() { name = "Dwarf", walkspeed = 25});
        races.Add(new race() { name = "Elf", walkspeed = 30});
        races.Add(new race() { name = "Gnome", walkspeed = 25});
        races.Add(new race() { name = "Half-Elf", walkspeed = 30});
        races.Add(new race() { name = "Half-Orc", walkspeed = 30});
        races.Add(new race() { name = "Halfling", walkspeed = 25});
        races.Add(new race() { name = "Human", walkspeed = 30});
        races.Add(new race() { name = "Tiefling", walkspeed = 30});

        classplay.Add(new playerclass() { name = "Character's  Class?", hp = 0 });
        classplay.Add(new playerclass() { name = "Barbarian", hp = 12 });
        classplay.Add(new playerclass() { name = "Bard",  hp = 8 });
        classplay.Add(new playerclass() { name = "Cleric",  hp = 8 });
        classplay.Add(new playerclass() { name = "Druid", hp = 8 });
        classplay.Add(new playerclass() { name = "Fighter",  hp = 10 });
        classplay.Add(new playerclass() { name = "Monk",  hp = 8 });
        classplay.Add(new playerclass() { name = "Paladin",  hp = 10 });
        classplay.Add(new playerclass() { name = "Ranger",  hp = 10 });
        classplay.Add(new playerclass() { name = "Rogue",  hp = 8 });
        classplay.Add(new playerclass() { name = "Sorcerer", hp = 6 });
        classplay.Add(new playerclass() { name = "Warlock", hp = 8 });
        classplay.Add(new playerclass() { name = "Wizard", hp = 6 });
    }

    //find matching class & updates it's corresponding values
    public void characterclass()
    {
        string nameMatch = GameObject.Find("classlabel").GetComponent<Text>().text;
        playerclass matching = (classplay.Find(x => x.name == nameMatch));
        Pdat.instance.Pl.playerClass = matching.name;
        Pdat.instance.Pl.hp = matching.hp;
        acCalc();
        hpCalc();
    }

    //find matching race & updates it's corrosponding values
    public void characterrace()
    {
        string nameMatch = GameObject.Find("racelabel").GetComponent<Text>().text;
        race matching = (races.Find(x => x.name == nameMatch));
        GameObject.Find("WSval").GetComponent<Text>().text = matching.walkspeed.ToString();
        Pdat.instance.Pl.race = matching.name;
        Pdat.instance.Pl.walkSpeed = matching.walkspeed;
    }

    //Detects namechanges and adds it to instance
    public void namechange()
    {
        Pdat.instance.Pl.characterName = GameObject.Find("Nameval").GetComponent<Text>().text;
    }

    //Same as namechange, except for alignment
    public void Alignment()
    {
        Pdat.instance.Pl.alignment = GameObject.Find("Alval").GetComponent<Text>().text;
    }

    //Sorts rolls, totals the largest 2d6 & 2d4, to return total.
    public void statroller(string stat)
    {
        //Number of rolls for the dice
        int d6Total = 4;

        //list to store rolls
        List<int> d6roll = new List<int>();

        int total;
        for (int i = 0; i < d6Total; i++)
        {
            d6roll.Add(Random.Range(1, 7));
        }
        d6roll.Sort();
        total = d6roll[1] + d6roll[2] + d6roll[3];
        GameObject.Find(stat).GetComponent<Text>().text = total.ToString();

        //Modifies instance stat based off of stat being rolled
        switch (stat)
        {
            case "Str": Pdat.instance.Pl.abilityStr = total; break;
            case "Dex":
                {
                    Pdat.instance.Pl.abilityDex = total;
                    acCalc();
                    break;
                }
            case "Con":
                {
                    Pdat.instance.Pl.abilityCon = total;
                    acCalc();
                    hpCalc();
                    break;
                }
            case "Int": Pdat.instance.Pl.abilityInt = total; break;
            case "Wis":
                {
                    Pdat.instance.Pl.abilityWis = total;
                    acCalc();
                    break;
                }
            case "Cha": Pdat.instance.Pl.abilityCha = total; break;
        }
    }

    //Converts the PlayerData instance into a json file, then outputs it to a window
    public void finalize()
    {

        acCalc();
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

        GameObject.Find("ACval").GetComponent<Text>().text = AC.ToString();
        Pdat.instance.Pl.armorClass = AC;
    }

    public void hpCalc()
    {
        Pdat.instance.Pl.hp = (Pdat.instance.Pl.hp + (((int)Pdat.instance.Pl.abilityCon - 10) / 2));
        GameObject.Find("Hpval").GetComponent<Text>().text = Pdat.instance.Pl.hp.ToString();
    }
}
