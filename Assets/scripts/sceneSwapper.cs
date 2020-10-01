using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{
    public void backButton()
    {
        Debug.Log("TO THE MAIN");
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

    }
}