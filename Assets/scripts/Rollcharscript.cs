using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollcharscript : MonoBehaviour
{
    //Sorts rolls, totals the largest 2d6 & 2d4, to return total.
    public void statroller()
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
        Debug.Log(total + " d6rolls: " + d6roll[2] + " " + d6roll[1] + " " + d6roll[0] + "\nd4rolls:" + d4roll[2] + " " + d4roll[1] + " " + d4roll[0]);
        d6roll.Clear();
        d4roll.Clear();
        //return total;
    }
}
