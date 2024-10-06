using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public Dictionary<string, int> poolSize;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        poolSize = new Dictionary<string, int>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            GameObject fileObject = new GameObject("@" + pool.tag);
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab); 
                obj.transform.SetParent(fileObject.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
            poolSize.Add(pool.tag, pool.size);
            
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        if (poolDictionary[tag] == null)
        {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }    
}
