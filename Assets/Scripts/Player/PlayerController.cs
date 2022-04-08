﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //A Reference to the playerShip
    GameObject playerShip;
    ShipController shipController;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        playerShip = GameObject.Find("Player");
        shipController = playerShip.GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementControls();
    }

    /// <summary>
    /// This function controls the player space ship
    /// </summary>
    void MovementControls()
    {
        //For testing within the Editor
#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
#endif
    }

    public void RotateLeft()
    {
        shipController.Rotate(shipController.shipProperties.rotationRate);
    }

    public void RotateRight()
    {
        shipController.Rotate(-shipController.shipProperties.rotationRate);
    }

    public void Shoot()
    {
        shipController.Shoot();
    } 

    public void ButtonPressed()
    {
        Debug.Log("Pressed");
    }
}
