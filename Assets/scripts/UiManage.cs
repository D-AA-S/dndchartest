using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiManage : MonoBehaviour
{
    public Text description;
    public GameObject rollchoice;
    private int selection;
    void Start()
    {
        rollchoice.GetComponent<Dropdown>().value = Pdat.instance.Pl.abilityChoice;
    }

    public void settingchanged()
    {
        selection = rollchoice.GetComponent<Dropdown>().value;
        textdescription(selection);
    }

    private void textdescription(int rollChoice)
    {
        switch (rollChoice)
        {
            case 0:
                description.text = "Rolls 4 six-sided dice, and drops the lowest roll" +
                    " before totalling, more likely to give higher rolls";
                Pdat.instance.Pl.abilityChoice = rollChoice;
                break;
            case 1:
                description.text = "Rolls 3 six-sided dice and totalls the values at " +
                    "face value, comparatively lower totals than 4d6 lowest dropped";
                Pdat.instance.Pl.abilityChoice = rollChoice;
                break;
            case 2:
                description.text = "Uses fixed numbers to allocate stats, " +
                    "distributing the numbers 15, 14, 13, 12, 10, 8, to randomly selected stats.";
                Pdat.instance.Pl.abilityChoice = rollChoice;
                break;
        }
    }
}
