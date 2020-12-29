using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiManage : MonoBehaviour
{
    public Text description;
    public Text rollchoice; 
    void Start()
    {
        textdescription("4d6 Lowest Dropped(Default)");
    }

    public void settingchanged()
    {
        textdescription(rollchoice.text);
    }

    private void textdescription(string rollChoice)
    {
        switch (rollChoice)
        {
            case "4d6 Lowest Dropped(Default)":
                description.text = "Rolls 4 six-sided dice, and drops the lowest roll" +
                    " before totalling, more likely to give higher rolls";
                break;
            case "3d6 Nothing Dropped":
                description.text = "Rolls 3 six-sided dice and totalls the values at " +
                    "face value, comparatively lower totals than 4d6 lowest dropped";
                break;
            case "15-8 Random Stat Distribution":
                description.text = "Uses fixed numbers to allocate stats, " +
                    "distributing the numbers 15, 14, 13, 12, 10, 8, to randomly selected stats.";
                break;
        }
    }
}
