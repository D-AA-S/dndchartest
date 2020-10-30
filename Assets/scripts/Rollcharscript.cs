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
        races.Add(new race() {name = "Character's  Race?", walkspeed = 0, runspeed = 0, jumpheight = 0, description = "" });
        races.Add(new race() {name = "Dragonborn", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your draconic heritage manifests in a variety of traits you share with other dragonborn."});
        races.Add(new race() {name = "Dwarf", walkspeed = 25, runspeed = 50, jumpheight = 10, description = "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature."});
        races.Add(new race() {name = "Elf", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement."});
        races.Add(new race() {name = "Gnome", walkspeed = 25, runspeed = 50, jumpheight = 10, description = "Your gnome character has certain characteristics in common with all other gnomes."});
        races.Add(new race() {name = "Half-Elf", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your half-elf character has some qualities in common with elves and some that are unique to half-elves."});
        races.Add(new race() {name = "Half-Orc", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your half-orc character has certain traits deriving from your orc ancestry."});
        races.Add(new race() {name = "Halfling", walkspeed = 25, runspeed = 50, jumpheight = 10, description = "Your halfling character has a number of traits in common with all other halflings."});
        races.Add(new race() {name = "Human", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "It's hard to make generalizations about humans, but your human character has these traits."});
        races.Add(new race() {name = "Tiefling", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Tieflings share certain racial traits as a result of their infernal descent."});

        classplay.Add(new playerclass() {name = "Character's  Class?", description = "", hp = 0});
        classplay.Add(new playerclass() {name = "Barbarian" , description = "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end–that end being violence.", hp = 12});
        classplay.Add(new playerclass() {name = "Bard", description = "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound.", hp = 8});
        classplay.Add(new playerclass() {name = "Cleric", description = "Clerics act as conduits of divine power.", hp = 8});
        classplay.Add(new playerclass() {name = "Druid", description = "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities.", hp = 8});
        classplay.Add(new playerclass() {name = "Fighter", description = "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it.", hp = 10 });
        classplay.Add(new playerclass() {name = "Monk", description = "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces.", hp = 8 });
        classplay.Add(new playerclass() {name = "Paladin", description = "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends.", hp = 10});
        classplay.Add(new playerclass() {name = "Ranger", description = "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies.", hp = 10 });
        classplay.Add(new playerclass() {name = "Rogue", description = "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes.", hp = 8 });
        classplay.Add(new playerclass() {name = "Sorcerer", description = "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. As a sorcerer the power of your magic relies on your ability to project your will into the world.", hp = 6});
        classplay.Add(new playerclass() { name = "Warlock", description = "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells.", hp = 8 });
        classplay.Add(new playerclass() { name = "Wizard", description = "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells.", hp = 6 });
    }

    //find matching class & updates it's corresponding values
    public void characterclass()
    {
        string nameMatch = GameObject.Find("classlabel").GetComponent<Text>().text;
        playerclass matching = (classplay.Find(x => x.name == nameMatch));
        GameObject.Find("classdesc").GetComponent<Text>().text = matching.description;
        GameObject.Find("Hpval").GetComponent<Text>().text = matching.hp.ToString();
        Pdat.instance.Pl.playerclass = matching.name;
        Pdat.instance.Pl.hpdie = matching.hp;
    }

    //find matching race & updates it's corrosponding values
    public void characterrace()
    {
        string nameMatch = GameObject.Find("racelabel").GetComponent<Text>().text;
        race matching = (races.Find(x => x.name == nameMatch));
        GameObject.Find("racedesc").GetComponent<Text>().text = matching.description;
        GameObject.Find("WSval").GetComponent<Text>().text = matching.walkspeed.ToString();
        GameObject.Find("RSval").GetComponent<Text>().text = matching.runspeed.ToString();
        GameObject.Find("JHval").GetComponent<Text>().text = matching.jumpheight.ToString();
        Pdat.instance.Pl.race = matching.name;
        Pdat.instance.Pl.walkspeed = matching.walkspeed;
        Pdat.instance.Pl.runspeed = matching.runspeed;
        Pdat.instance.Pl.jumpheight = matching.jumpheight;
    }

    //Detects namechanges and adds it to instance
    public void namechange()
    {
        Pdat.instance.Pl.character_name = GameObject.Find("Nameval").GetComponent<Text>().text;
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

        //Calculates Ac based of base 10 value plus modifier
        if (stat == "Dex")
        {
            int AC = (10 + ((total - 10) / 2));
            GameObject.Find("ACval").GetComponent<Text>().text = AC.ToString();
            Pdat.instance.Pl.Armourclass = AC;
        }
        if (stat == "Con")
        {
            int hpsum = (Pdat.instance.Pl.hpdie + ((total - 10) / 2));
            GameObject.Find("Hpval").GetComponent<Text>().text = hpsum.ToString();
            Pdat.instance.Pl.currenthp = hpsum;
            Pdat.instance.Pl.maxhp = hpsum;
        }

        //Modifies instance stat based off of stat being rolled
        switch (stat)
        {
            case "Str": Pdat.instance.Pl.ability_str = total; break;
            case "Dex": Pdat.instance.Pl.ability_dex = total; break;
            case "Con": Pdat.instance.Pl.ability_con = total; break;
            case "Int": Pdat.instance.Pl.ability_int = total; break;
            case "Wis": Pdat.instance.Pl.ability_wis = total; break;
            case "Cha": Pdat.instance.Pl.ability_cha = total; break;
        }
    }

    //Converts the PlayerData instance into a json file, then outputs it to a window
    public void finalize()
    {
        string json = JsonUtility.ToJson(Pdat.instance.Pl);
        GameObject.Find("Jsonout").GetComponent<Text>().text = json;
    }

    public class race
    {
        public string name = "";
        public string description = "";
        public int walkspeed = 0;
        public int runspeed = 0;
        public int jumpheight = 0;
    }
    public class playerclass
    {
        public string name = "";
        public string description = "";
        public int hp = 0;
    }

    public class acupdate
    {

    }

    public class hpupdate
    {

    }
}
