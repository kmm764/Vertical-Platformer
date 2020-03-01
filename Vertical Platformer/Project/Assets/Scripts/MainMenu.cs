using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //menu to start game
    public void StartGame()
    {
        SceneManager.LoadScene("intro");
    }
    //quite game method
    public void QuitGame()

    {
        Application.Quit();
    }

    //return to menu method
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //start level 1 method
    public void Startlevel1()
    {
        //SceneManager.UnloadSceneAsync("intro");
        SceneManager.LoadScene("level1");
        
    }

    //to tutorial
    public void toControls()

    {
        SceneManager.LoadScene("Controls");
    }

    // to level 2
    public void Startlevel2()
    {
        SceneManager.LoadScene("level2");
    }
    //to level 3
    public void Startlevel3()
    {
        SceneManager.LoadScene("level3");
    }
}
