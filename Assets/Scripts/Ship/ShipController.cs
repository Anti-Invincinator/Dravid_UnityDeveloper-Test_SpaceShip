using UnityEngine;

public class ShipController : MonoBehaviour
{   
    /// <summary>
    /// This structure contains all the properties of the ship
    /// </summary>
    [System.Serializable]
    public struct ShipProperties
    {
        [Header("Ship Properties")]
        [Tooltip("Speed of the SpaceShip")]
        public float speed;

        [Tooltip("RotationRate of the SpaceShip; i.e. How fast it rotates")]
        public float rotationRate;

        [Tooltip("Cooldown between each time the SpaceShip can Shoot")]
        public float fireRate;

        public ShipProperties(float speed, float rotationRate, float fireRate)
        {
            this.speed = speed;
            this.rotationRate = rotationRate;
            this.fireRate = fireRate;
        }

        public ShipProperties (ShipProperties shipProperties)
        {
            this.speed = shipProperties.speed;
            this.rotationRate = shipProperties.rotationRate;
            this.fireRate = shipProperties.fireRate;
        }
    }

    //time the previous bullet was shot
    private float prevBullet;

    public ShipProperties shipProperties;

    private void Start()
    {
        prevBullet = Time.time;
    }

    void Update()
    {
         Move();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(shipProperties.rotationRate);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(-shipProperties.rotationRate);
        }

        if(Input.GetKeyDown(KeyCode.Space) &&
            Time.time - prevBullet >= shipProperties.fireRate //Fire Rate Check
            )
        {
            Shoot();

            prevBullet = Time.time;
        }    
    }

    //Makes the ship move constantly towards where it's pointing
    private void Move()
    {
        transform.position += transform.up * shipProperties.speed * Time.deltaTime;
    }


    //To Rotate the Ship ClockWise and CounterClockWise
    private void Rotate(float rotationRate)
    {
        transform.Rotate(
            new Vector3(0, 0, rotationRate * Time.deltaTime)
            );
    }


    //The Shoot function; Draws an instance of bullet from the Object Pooler
    private void Shoot()
    {
        ObjectPooler._instance.SpawnObject(this.transform.position, this.transform.rotation);
    }
}
