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
}