using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This ScriptableObject is to store data referring to the configuration of a wave of enemies including:
    1.The number of enemies in the wave
    2.Their direction across the screen (via a series of locations of "waypoint" gameObjects)
    3.Their spawn rate
    4.Their movement speed
    5.Their firerate
    6.Their health
*/
[CreateAssetMenu(menuName = "Wave Configuration",  fileName = "New Wave Configuration")]
public class WaveConfigurationSO : ScriptableObject
{

    [Header("Enemy Wave Prefab information")]
    [SerializeField] List<GameObject> enemyPrefabsThisWave;//List of all enemies this wave
    [SerializeField] Transform enemyPathPrefab;//the path they will take this wave
    [Header("Enemy Wave Spawnrate")]
    [SerializeField] float averageTimeBetweenEnemySpawns = 1f; //The time in seconds between enemy spawns
    [SerializeField] float enemySpawnTimeVariability = 0.5f; //The amount of random variance between enemy spawns
    [SerializeField] float minimumTimeBetweenEnemySpawns = 0.2f; //The minimum amount of time between enemy spawns (if value goes under minimum, spawntime defaults to this value)
    [Header("Enemy stats")]
    [SerializeField] float enemyMovementSpeed = 5f;//the movement speed of these enemies
    [SerializeField] float enemyFireRate = 1f;//The fire rate of the enemies being spawned this wave
    [SerializeField] float enemyHealth = 100f;//the health of each individual enemy

    
    //returns the number of enemies that will spawn this wave
    public int GetEnemyCount(){
        return enemyPrefabsThisWave.Count;
    }

    public GameObject GetEnemyPrefabAtIndex(int index){
        return enemyPrefabsThisWave[index];
    }

    //getter for the starting waypoint (spawn point) of this wave
    public Transform GetStartingWaypointOnEnemyPathPrefab(){
        return enemyPathPrefab.GetChild(0);
    }

    //getter for all waypoints on path for this wave
    public List<Transform> GetAllWaypointsOnEnemyPathPrefab(){
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in enemyPathPrefab){
            waypoints.Add(child);
        }
        return waypoints;
    }

    //getter for a random spawn time for the next enemy(range creates value below minimumTime then will just return the minimum value for spawnrate)
    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(averageTimeBetweenEnemySpawns - enemySpawnTimeVariability, averageTimeBetweenEnemySpawns + enemySpawnTimeVariability);
        if (spawnTime < minimumTimeBetweenEnemySpawns) {
            return minimumTimeBetweenEnemySpawns;
        }
        else {
            return spawnTime;          
        }
    }
    
    //getter for enemy movement speed for this wave
    public float GetEnemyMovementSpeed(){
        return enemyMovementSpeed;
    }
}
