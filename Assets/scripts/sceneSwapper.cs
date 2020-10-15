using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Swaps between scenes based off of the chosen function in the Ui button object
public class sceneSwapper : MonoBehaviour
{
    public void backButton()
    {
        SceneManager.LoadScene("Main menu"); 
    }
    public void unimplemented()
    {
        SceneManager.LoadScene("Unimplemented");
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void about()
    {
        SceneManager.LoadScene("About");
    }
    public void quit()
    {
        Debug.Log("If this were an application we would quit here");
    }
    public void rollcha()
    {
        SceneManager.LoadScene("RollChar");
    }
}