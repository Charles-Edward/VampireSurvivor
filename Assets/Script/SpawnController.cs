using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _spawnRate;
    [SerializeField]
    private float _newSpawnRate = 0.1f;

    // Private & Protected
    private float _nextTimeToSpawn;
    private KillCountManager _killCountManager;
    private EnemyController _enemyController;
    void Start()
    {
        
    }

    void Update()
    {
        EnemySpawnNorth();
    }
    private void FixedUpdate()
    {
        
        
    }

    private void EnemySpawnNorth()
    {
        if (Time.timeSinceLevelLoad > _nextTimeToSpawn)
        {
            _nextTimeToSpawn = Time.timeSinceLevelLoad + _spawnRate;
            // Spawn North
            int xPos = Random.Range(-40,40);
            int yPos = Random.Range(20, 25);
            Instantiate(_enemyPrefab, new Vector2(xPos,yPos), Quaternion.identity);
            // Spawn East
            int xPosE = Random.Range(36, 40);
            int yPosE = Random.Range(-23, 23);
            Instantiate(_enemyPrefab, new Vector2(xPosE, yPosE), Quaternion.identity);
            //Spawn South
            int xPosS = Random.Range(-40, 40);
            int yPosS = Random.Range(-24, -20);
            Instantiate(_enemyPrefab, new Vector2(xPosS, yPosS), Quaternion.identity);
            // Spawn West
            int xPosW = Random.Range(-40, -35);
            int yPosW = Random.Range(-23, 23);
            Instantiate(_enemyPrefab, new Vector2(xPosW, yPosW), Quaternion.identity);
            Debug.Log("Spawn");

        }

            
    }


}
