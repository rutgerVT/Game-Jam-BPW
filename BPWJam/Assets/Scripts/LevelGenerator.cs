using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    

    public GameObject startingChunk;
    public enum Direction { Left, Right }
    public Direction direction;
    private int directionalMultiplier;

    private Vector3 nextPosition;
    
    private GameObject[] levelChunks;
    private GameObject currentChunk;
    private float spawnInterval;
    private float chunkSize;

    private void Start()
    {
        spawnInterval = GameManager.Instance.spawnInterval;
        chunkSize = GameManager.Instance.chunkSize;
        levelChunks = GameManager.Instance.levelChunks;

        if (direction == Direction.Right) { directionalMultiplier = 1; }
        else if (direction == Direction.Left) { directionalMultiplier = -1; }

        currentChunk = startingChunk;
        startingChunk.GetComponent<LevelChunk>()?.SetVelocity(GameManager.Instance.chunkVelocity * directionalMultiplier);

        nextPosition = new Vector3(chunkSize * 0.5f * directionalMultiplier, currentChunk.transform.position.y, 0);
        StartCoroutine(SpawnChunk());
    }

    void Update()
    {
        
    }

    public IEnumerator SpawnChunk()
    {
        while(true)
        {
            nextPosition = new Vector3(currentChunk.transform.position.x + (chunkSize * -directionalMultiplier), currentChunk.transform.position.y, 0);
            Debug.Log(nextPosition);
            GameObject newChunkObject = Instantiate(GameManager.Instance.GetRandomChunk(), nextPosition, Quaternion.identity);
            newChunkObject.GetComponent<LevelChunk>()?.SetVelocity(GameManager.Instance.chunkVelocity * directionalMultiplier);
            //newChunkObject.transform.localScale *= directionalMultiplier;
            currentChunk = newChunkObject;
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
