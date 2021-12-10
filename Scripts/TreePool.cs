
using System;
using System.Collections.Generic;
using UnityEngine;

public class TreePool : MonoBehaviour
{
    public List<GameObject> pool;
    public GameObject prefab;
    public int poolAmount;
    [SerializeField]private bool shouldExpand;
    
    private static TreePool _instance;
    public static TreePool Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        pool = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledTree()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }

        if (shouldExpand)
        {
            GameObject obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}
