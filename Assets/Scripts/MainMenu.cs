using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        //Loads the save data
        GameData.LoadData();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// Saves the game data and quits the game
    /// </summary>
    public void QuitGame()
    {
        
        GameData.SaveData();
        Application.Quit();
    }
}
