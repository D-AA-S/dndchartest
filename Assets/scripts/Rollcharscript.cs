using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollcharscript : MonoBehaviour
{
    List<race> races = new List<race>();
    public void initialization()
    {

        new race() { name = "Dragonborn", walkspeed = 30, runspeed = 60, jumpheight = 15, description = "The study of wizardry is ancient, stretching back to the earliest mortal discoveries of magic. As a student of arcane magic, " +
             "you have a spellbook containing spells that show glimmerings of your true power which is a catalyst for your mastery over certain spells."};
    }


    public void characterclass()
    {

    }

    public void characterrace()
    {
        
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
        string name = "";
        string description = "";
        int hp = 0;
    }
}
