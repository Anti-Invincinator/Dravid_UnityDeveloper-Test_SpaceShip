using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will allow us to achieve object pooling for the bullets, it's a single object object pooling instance 
/// Use a dictionary of queue for pooling of multiple objects
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    #region Singleton
    public static ObjectPooler _instance;
    private void Awake()
    {
        _instance = this;
    }
    #endregion //!Singleton
    
    public Queue<GameObject> pooledObjects;
    public GameObject objectToPool;

    public int amountToPool;

    private void Start()
    {
        pooledObjects = new Queue<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject instance = Instantiate(objectToPool);
            instance.SetActive(false);

            pooledObjects.Enqueue(instance);
        }
    }

    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = pooledObjects.Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        pooledObjects.Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
