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
        [Tooltip("Object Name of the Ship")]
        public string name;

        [Tooltip("Speed of the SpaceShip")]
        public float speed;

        [Tooltip("RotationRate of the SpaceShip; i.e. How fast it rotates")]
        public float rotationRate;

        [Tooltip("Cooldown between each time the SpaceShip can Shoot")]
        public float fireRate;

        //Parameterized Constructor
        public ShipProperties(string name, float speed, float rotationRate, float fireRate)
        {
            this.name = name;
            this.speed = speed;
            this.rotationRate = rotationRate;
            this.fireRate = fireRate;
        }

        //Copy Constructor
        public ShipProperties (ShipProperties shipProperties)
        {
            this.name = shipProperties.name;
            this.speed = shipProperties.speed;
            this.rotationRate = shipProperties.rotationRate;
            this.fireRate = shipProperties.fireRate;
        }
    }

    //time the previous bullet was shot
    public float prevBullet;

    public ShipProperties shipProperties;

    private void OnEnable()
    {
        prevBullet = Time.time;
    }

    void Update()
    {
         Move();  
    }

    //Makes the ship move constantly towards where it's pointing
    private void Move()
    {
        transform.position += transform.up * shipProperties.speed * Time.deltaTime;
    }


    //To Rotate the Ship ClockWise and CounterClockWise
    public void Rotate(float rotationRate)
    {
        transform.Rotate(
            new Vector3(0, 0, rotationRate * Time.deltaTime)
            );
    }


    //The Shoot function; Draws an instance of bullet from the Object Pooler
    public void Shoot()
    {
        if(Time.time - prevBullet >= shipProperties.fireRate) //FireRate Check
        {
            ObjectPooler._instance.SpawnObject(this.transform.position, this.transform.rotation);

            prevBullet = Time.time;
        }       
    }
}
