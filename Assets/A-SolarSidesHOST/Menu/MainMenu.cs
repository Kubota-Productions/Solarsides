using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Unpause the game
        Time.timeScale = 1;

        // Load the desired scene
        SceneManager.LoadSceneAsync("Kamran's whiteboxing scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}