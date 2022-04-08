using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ShipController.ShipProperties playerShipProperties;
    public ShipController.ShipProperties enemyShipProperties;

    //The Ship Prefab to Spawn
    public GameObject ShipPrefab;

    //A reference to the PlayerController Instance
    public PlayerController playerControllerRef;

    private void Awake()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetGame();
    }

    private void OnEnable()
    {
        SpawnShips();
        ResetUI();

        //A Failsafe to Enable to playerController Script only when the player spaceship is spawned
        playerControllerRef.gameObject.SetActive(true);
        
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
        playerShip.GetComponent<ShipController>().shipProperties = new ShipController.ShipProperties(playerShipProperties);                                                                          //Adding the Player Controller Class

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
