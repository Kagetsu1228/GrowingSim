
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeController : MonoBehaviour
{
    [SerializeField] private int forestSize;
    [SerializeField] private Vector2 forestDimensions;


    private Vector3 GetRandomPosition(float positionY)
    {
        float randomX = Random.Range(-forestDimensions.x / 2, forestDimensions.x / 2);
        float randomZ = Random.Range(-forestDimensions.y / 2, forestDimensions.y / 2);

        return new Vector3(randomX, positionY, randomZ);
    }
    private void Start()
    {
        for (int i = 0; i < forestSize; i++)
        {
            SpawnTree();
        }
    }

    private void SpawnTree()
    {
        GameObject newTree = TreePool.Instance.GetPooledTree();
        if (newTree == null) return;

        newTree.transform.position = GetRandomPosition(transform.position.y);
    }

    private void OnEnable()
    {
        GameObject.OnTreeDeath += SpawnTree;
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        var color = Gizmos.color;
        Gizmos.color = Color.green;
        Vector3 size = new Vector3(forestDimensions.x, 1, forestDimensions.y);
        Gizmos.DrawWireCube(transform.position, size);
    }
    #endif
}
