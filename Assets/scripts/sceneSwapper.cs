using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Swaps between scenes based off of the chosen function in the Ui button object
public class sceneSwapper : MonoBehaviour
{
    public void sceneswap(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void quit()
    {
        Debug.Log("If this were an application we would quit here");
    }
    //Number of rolls for the dice
    static int d6Total = 3;
    static int d4Total = 3;
    //list to store rolls
    List<float> d4roll;
    List<float> d6roll;

    //Sorts rolls, totals the largest 2d6 & 2d4, to return total.
    public float statroller()
    {
        float total;
        for (int i = 0; i < d6Total; i++)
        {
            d6roll.Add(Random.Range(1, 6));
        }
        for (int i = 0; i < d4Total; i++)
        {
            d4roll.Add(Random.Range(1, 4));
        }
        d6roll.Sort();
        d4roll.Sort();
        total = d6roll[1] + d6roll[2] + d4roll[1] + d4roll[2];
        Debug.Log(total);
        d6roll.Clear();
        d4roll.Clear();
        return total;
    }
}