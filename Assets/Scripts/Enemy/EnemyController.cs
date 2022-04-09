using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //A Reference to the shipController
    ShipController shipController;

    [Tooltip("A Reference to the player ship")]
    public Transform PlayerShip;


    private void Awake()
    {
        shipController = GetComponent<ShipController>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Time.time - shipController.prevBullet > shipController.shipProperties.fireRate)
        {
            LookAndShootAtPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            collision.gameObject.SetActive(false);

            GameManager._instance.IncreasePlayerScore();
        }
    }


    public void LookAndShootAtPlayer()
    {

        //Look at player
       Transform target = PlayerShip;
       
       Vector2 targetDirection = target.position - transform.position;
       
       float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
       
       Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       
       transform.rotation = Quaternion.Slerp(transform.rotation, rotation, shipController.shipProperties.rotationRate * Time.deltaTime);

        //Shoot at player
        shipController.Shoot("EnemyBullet", Color.black);
    }
}
