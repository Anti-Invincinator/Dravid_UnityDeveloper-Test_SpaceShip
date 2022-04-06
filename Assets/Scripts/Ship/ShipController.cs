using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Ship Properties")]
    [Tooltip("Speed of the SpaceShip")]
    public float speed;

    [Tooltip("RotationRate of the SpaceShip; i.e. How fast it rotates")]
    public float rotationRate;

    [Tooltip("Cooldown between each time the SpaceShip can Shoot")]
    public float fireRate;
    
    //time the previous bullet was shot
    private float prevBullet;

    private void Start()
    {
        prevBullet = Time.time;
    }

    void Update()
    {
         Move();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(rotationRate);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(-rotationRate);
        }

        if(Input.GetKeyDown(KeyCode.Space) &&
            Time.time - prevBullet >= fireRate //Fire Rate Check
            )
        {
            Shoot();

            prevBullet = Time.time;
        }    
    }

    //Makes the ship move constantly towards where it's pointing
    private void Move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
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
