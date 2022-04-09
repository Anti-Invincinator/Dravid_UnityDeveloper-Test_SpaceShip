using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //A Reference to the shipController
    ShipController shipController;

    //Boolean to check whether to rotate Clock or Counter Clockwise
    bool rotateAntiClockWise;
    bool rotateClockWise;
    
    private void Awake()
    {
        shipController = GetComponent<ShipController>();
    }

    private void OnEnable()
    {
        shipController = GetComponent<ShipController>();
    }

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

        if (rotateAntiClockWise)
            RotateLeft();

        if (rotateClockWise)
            RotateRight();
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
        shipController.Shoot("PlayerBullet", Color.white);
    } 

    public void setRotateClockWise(bool boolean)
    {
        rotateClockWise = boolean;
    }
    
    public void setRotateAntiClockWise(bool boolean)
    {
        rotateAntiClockWise = boolean;
    }

    //To check for collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            collision.gameObject.SetActive(false);

            GameManager._instance.IncreaseEnemyScore();
        }
    }
}
