using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Swaps between scenes based off of the chosen function in the Ui button object
public class SceneSwapper : MonoBehaviour
{
    public bool flip = true;
    private GameObject activeCanvas;
    public GameObject About;
    public GameObject Settings;
    public GameObject mainMenu;

    public void Awake()
    {
        activeCanvas = mainMenu;
    }

    //swaps scenes through the given string input
    public void sceneswap(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void quit()
    {
        Application.Quit();
    }

    public void nextcanvas(GameObject canvas)
    {
        activeCanvas.SetActive(false);
        canvas.SetActive(true);
        activeCanvas = canvas;
    }
}