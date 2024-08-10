using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This ScriptableObject is to store data referring to the configuration of a wave of enemies including:
    1.The number of enemies in the wave
    2.Their direction across the screen (via a series of locations of "waypoint" gameObjects)
    3.Their movement speed
    4.Their firerate
    5.Their health
*/
[CreateAssetMenu(menuName = "Wave Configuration",  fileName = "New Wave Configuration")]
public class WaveConfigurationSO : ScriptableObject
{

    [Header("Enemy Prefab information")]
    [SerializeField] List<GameObject> enemyPrefabsThisWave;//List of all enemies this wave
    [SerializeField] Transform enemyPathPrefab;//the path they will take this wave
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
    
    //getter for enemy movement speed for this wave
    public float GetEnemyMovementSpeed(){
        return enemyMovementSpeed;
    }
}
