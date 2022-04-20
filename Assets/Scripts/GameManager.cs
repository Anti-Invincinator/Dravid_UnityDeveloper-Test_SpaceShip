using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager _instance;
    private void Awake()
    {
        _instance = this;
    }
    #endregion //!Singleton


    [Header("UI Elements")]
    //This is a reference to the pause screen
    public GameObject PauseScreen;
    public GameObject GameOverScreen;

    //Reference to Player and EnemyScore
    public Text PlayerScoreText;
    public Text EnemyScoreText;

    public Text GameOverText;

    private int playerScore;
    private int enemyScore;

    [Tooltip("Score Limit till which the game has to be played")]
    public int scoreLimit = 10;

    private void OnEnable()
    {
        ResetUI();
        GameData.addTry();
    }

    public void UpdateScore()
    {
        PlayerScoreText.text = playerScore.ToString();
        EnemyScoreText.text = enemyScore.ToString();

        //Check for game over
        if(playerScore >= scoreLimit)
        {
            GameOver("You Win");
            GameData.addWin();
        }
        else if(enemyScore >= scoreLimit)
        {
            GameOver("You Lose");
        }
    }

    //Increases and Updates PlayerScore
    public void IncreasePlayerScore()
    {
        playerScore++;
        UpdateScore();
    }
    
    //Increases and Updates EnemyScore
    public void IncreaseEnemyScore()
    {
        enemyScore++;
        UpdateScore();
    }

    /// <summary>
    /// Resume the game by setting the timescale back to normal  
    /// </summary>
    public void ResumeGame()
    {
        PauseScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Pauses the Game by setting the timeScale
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.gameObject.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Resets the UI
    /// </summary>
    void ResetUI()
    {
        playerScore = 0;
        enemyScore = 0;

        UpdateScore();
    }

    /// <summary>
    /// GameOver UI and Text
    /// </summary>
    /// <param name="gameOverText"> Givesout whether we won or lost </param>
    void GameOver(string gameOverText)
    {
        Time.timeScale = 0;
        GameOverScreen.gameObject.SetActive(true);

        GameOverText.text = gameOverText;
    }


    /// <summary>
    /// Fail safe to save the data even when the game is closed mid-play
    /// </summary>
    private void OnApplicationQuit()
    {
        GameData.SaveData();
    }
}
