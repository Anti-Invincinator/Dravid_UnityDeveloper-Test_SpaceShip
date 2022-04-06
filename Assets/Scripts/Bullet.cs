using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Projectile Properties")]
    [Tooltip("Speed of the bullet")]
    public float bulletSpeed;
    [Tooltip("Duration before killing the bullet")]
    public float killTimer;

    private void OnEnable()
    {
        Invoke("DespawnBullet", killTimer);      
    }

    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    private void DespawnBullet()
    {
        //if no Object pooling is Present
        //Destroy(this, killTimer);

        //if Object pooling is there
        this.gameObject.SetActive(false);
    }
}
