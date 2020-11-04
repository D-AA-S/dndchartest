﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Swaps between scenes based off of the chosen function in the Ui button object
public class SceneSwapper : MonoBehaviour
{
    public bool flip = true;
    public GameObject RaceCanvas;
    public GameObject Classcanvas;
    //swaps scenes through the given string input
    public void sceneswap(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
        if (sceneToLoad == "RollChar")
        {
            //getting rollcharacter script to load during sceneswapping
            RollCharScript rcs = GameObject.Find("RollCharacter").GetComponent<RollCharScript>();
            rcs.initialization();
        }
    }
    public void quit()
    {
        Debug.Log("If this were an application we would quit here");
    }

    public void nextcanvas()
    {
        RaceCanvas.SetActive(!flip);
        Classcanvas.SetActive(flip);
        flip = !flip;
    }
}