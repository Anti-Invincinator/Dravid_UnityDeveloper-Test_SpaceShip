using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ShipController.ShipProperties playerShipProperties;
    public ShipController.ShipProperties enemyShipProperties;

    public GameObject ShipPrefab;


    private void Awake()
    {
        var playerShip = Instantiate(ShipPrefab, transform.position, Quaternion.identity);

        playerShip.GetComponent<ShipController>().shipProperties = new ShipController.ShipProperties(playerShipProperties);
    }

    private void Start()
    {
        
    }
}
