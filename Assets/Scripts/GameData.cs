using System;
using System.IO;
using UnityEngine;


public static class GameData 
{

    public static int numberOfTries = 0;
    public static int numberOfWins = 0;

    /// <summary>
    /// this function increases the number of tries the player had attempted
    /// </summary>
    /// <returns>it returns the total number of tries</returns>
    public static int addTry()
    {
        numberOfTries++;

        return numberOfTries;
    }

    /// <summary>
    /// This functions increases the number of the wins the player had gotten
    /// </summary>
    /// <returns>it returns the total number of wins</returns>
    public static int addWin()
    {
        numberOfWins++;

        return numberOfWins;
    }

    /// <summary>
    /// This functions loads the game data from the text file
    /// </summary>
    public static void LoadData()
    {
        numberOfTries = PlayerPrefs.GetInt("numberOfTries");
        numberOfWins = PlayerPrefs.GetInt("numberOfWins");
    }

    /// <summary>
    /// This functions saves the game data to the text file
    /// </summary>
    public static void SaveData()
    {
        PlayerPrefs.SetInt("numberOfTries", numberOfTries);
        PlayerPrefs.SetInt("numberOfWins", numberOfWins);
        PlayerPrefs.Save();
    }
    
}
