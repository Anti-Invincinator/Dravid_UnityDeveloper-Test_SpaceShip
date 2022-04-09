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

        //Parameterized Constructor
        public ShipProperties(float speed, float rotationRate, float fireRate)
        {
            this.speed = speed;
            this.rotationRate = rotationRate;
            this.fireRate = fireRate;
        }

        //Copy Constructor
        public ShipProperties (ShipProperties shipProperties)
        {
            this.speed = shipProperties.speed;
            this.rotationRate = shipProperties.rotationRate;
            this.fireRate = shipProperties.fireRate;
        }
    }

    //time the previous bullet was shot
    public float prevBullet;

    //Position to spawn bullet from
    public Transform bulletSpawn;

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


    /// <summary>
    /// Spawn and Shoot the bullet
    /// </summary>
    /// <param name="tag"> The tag to give to the bullet</param>
    /// <param name="color">the color to give to the bullet</param>
    public void Shoot(string tag, Color color)
    {
        if(Time.time - prevBullet >= shipProperties.fireRate) //FireRate Check
        {
           var bullet =  ObjectPooler._instance.SpawnObject(bulletSpawn.position, bulletSpawn.rotation);

            bullet.tag = tag;

            bullet.GetComponent<SpriteRenderer>().color = color;

            prevBullet = Time.time;
        }       
    }


}
