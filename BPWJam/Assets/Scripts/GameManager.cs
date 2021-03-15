using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] levelChunks;
    public float chunkVelocity;
    public float chunkSize;
    public float spawnInterval;
    public bool isPaused;

    public GameObject randomChunk;
    int requestCount = 1;



    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        }
        randomChunk = levelChunks[Random.Range(0, levelChunks.Length)];
    }
    public GameObject GetRandomChunk()
    {
        requestCount++;
        if (requestCount!=0 && requestCount % 2 == 0)
        {
            randomChunk = levelChunks[Random.Range(0, levelChunks.Length)];
        }
        return randomChunk;
    }
}
