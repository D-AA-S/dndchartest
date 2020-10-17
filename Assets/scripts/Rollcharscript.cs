﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollCharScript : MonoBehaviour
{
    List<race> races = new List<race>();
    List<playerclass> classplay = new List<playerclass>();
    public void initialization()
    {
        new race() {name = "Character's  Race?", walkspeed = 0, runspeed = 0, jumpheight = 0, description = "" };
        new race() {name = "Dragonborn", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your draconic heritage manifests in a variety of traits you share with other dragonborn."};
        new race() {name = "Dwarf", walkspeed = 25, runspeed = 50, jumpheight = 10, description = "Your dwarf character has an assortment of in abilities, part and parcel of dwarven nature."};
        new race() {name = "Elf", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your elf character has a variety of natural abilities, the result of thousands of years of elven refinement."};
        new race() {name = "Gnome", walkspeed = 25, runspeed = 50, jumpheight = 10, description = "Your gnome character has certain characteristics in common with all other gnomes."};
        new race() {name = "Half-Elf ", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your half-elf character has some qualities in common with elves and some that are unique to half-elves."};
        new race() {name = "Half-Orc", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Your half-orc character has certain traits deriving from your orc ancestry."};
        new race() {name = "Halfling", walkspeed = 25, runspeed = 50, jumpheight = 10, description = "Your halfling character has a number of traits in common with all other halflings."};
        new race() {name = "Human", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "It's hard to make generalizations about humans, but your human character has these traits."};
        new race() {name = "Tiefling", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "Tieflings share certain racial traits as a result of their infernal descent."};

        new playerclass() {name = "Character's  Class?", description = "", hp = 0};
        new playerclass() {name = "Barbarian" , description = "In battle, you fight with primal ferocity. For some barbarians, rage is a means to an end–that end being violence.", hp = 12};
        new playerclass() {name = "Bard", description = "Whether singing folk ballads in taverns or elaborate compositions in royal courts, bards use their gifts to hold audiences spellbound.", hp = 8};
        new playerclass() {name = "Cleric", description = "Clerics act as conduits of divine power.", hp = 8};
        new playerclass() {name = "Druid", description = "Druids venerate the forces of nature themselves. Druids holds certain plants and animals to be sacred, and most druids are devoted to one of the many nature deities.", hp = 8};
        new playerclass() {name = "Fighter", description = "Different fighters choose different approaches to perfecting their fighting prowess, but they all end up perfecting it.", hp = 10 };
        new playerclass() {name = "Monk", description = "Coming from monasteries, monks are masters of martial arts combat and meditators with the ki living forces.", hp = 8 };
        new playerclass() {name = "Paladin", description = "Paladins are the ideal of the knight in shining armor; they uphold ideals of justice, virtue, and order and use righteous might to meet their ends.", hp = 10};
        new playerclass() {name = "Ranger", description = "Acting as a bulwark between civilization and the terrors of the wilderness, rangers study, track, and hunt their favored enemies.", hp = 10 };
        new playerclass() {name = "Rogue", description = "Rogues have many features in common, including their emphasis on perfecting their skills, their precise and deadly approach to combat, and their increasingly quick reflexes.", hp = 8 };
        new playerclass() {name = "Sorcerer", description = "An event in your past, or in the life of a parent or ancestor, left an indelible mark on you, infusing you with arcane magic. As a sorcerer the power of your magic relies on your ability to project your will into the world.", hp = 6};
        new playerclass() { name = "Warlock", description = "You struck a bargain with an otherworldly being of your choice: the Archfey, the Fiend, or the Great Old One who has imbued you with mystical powers, granted you knowledge of occult lore, bestowed arcane research and magic on you and thus has given you facility with spells.", hp = 8 };
        new playerclass() { name = "Wizard", description = "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells.", hp = 6 };
    }


    public void characterclass()
    {
        string nameMatch = GameObject.Find("classlabel").GetComponent<Text>().text;
        classplay.Find(x => x.name.Contains(nameMatch));
        Debug.Log("found");
    }

    public void characterrace()
    {
        string nameMatch = GameObject.Find("racelabel").GetComponent<Text>().text;
    }

    //Sorts rolls, totals the largest 2d6 & 2d4, to return total.
    public void statroller(string stat)
    {
        //Number of rolls for the dice
        int d6Total = 3;
        int d4Total = 3;
        //list to store rolls
        List<float> d4roll = new List<float>();
        List<float> d6roll = new List<float>();

        float total;
        for (int i = 0; i < d6Total; i++)
        {
            d6roll.Add(Random.Range(1, 7));
        }
        for (int i = 0; i < d4Total; i++)
        {
            d4roll.Add(Random.Range(1, 5));
        }
        d6roll.Sort();
        d4roll.Sort();
        total = d6roll[1] + d6roll[2] + d4roll[1] + d4roll[2];
        GameObject.Find(stat).GetComponent<Text>().text = total.ToString();
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
}
