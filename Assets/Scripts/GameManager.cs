using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ShipController.ShipProperties playerShipProperties;
    public ShipController.ShipProperties enemyShipProperties;

    public GameObject ShipPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetGame();
    }

    private void OnEnable()
    {
        SpawnShips();
        ResetUI();
    }

    /// <summary>
    /// This Function Spawns the player and enemy, set it's properties
    /// </summary>
    void SpawnShips()
    {
        var playerShip = Instantiate(ShipPrefab, transform.position, Quaternion.identity);
        var enemyShip = Instantiate(ShipPrefab, transform.position + new Vector3(2, 0, 0), Quaternion.identity);

        playerShip.gameObject.tag = "Player";
        playerShip.gameObject.name = "Player";
        playerShip.GetComponent<ShipController>().shipProperties = new ShipController.ShipProperties(playerShipProperties);
        playerShip.AddComponent<PlayerController>();                                                                           //Adding the Player Controller Class

        enemyShip.gameObject.tag = "Enemy";
        enemyShip.gameObject.name = "Enemy";
        enemyShip.GetComponent<ShipController>().shipProperties = new ShipController.ShipProperties(enemyShipProperties);
    }

    /// <summary>
    /// Resets the Game
    /// </summary>
    void ResetGame()
    {
        ResetUI();

        Debug.Log("Go To Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Resets the UI
    /// </summary>
    void ResetUI()
    {

    }
}
