using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is to store data referring to the configuration of a wave of enemies including:
    1.Their direction across the screen (via a series of locations of "waypoint" gameObjects)
    2.Their movement speed
    3.Their firerate
    4.Their health
*/
[CreateAssetMenu(menuName = "Wave Configuration",  fileName = "New Wave Configuration")]
public class WaveConfigurationSO : ScriptableObject
{
    [SerializeField] Transform enemyPathPrefab;
    [SerializeField] float enemyMovementSpeed = 5f;
    [SerializeField] float enemyFireRate = 1f;
    [SerializeField] float enemyHealth = 100f;


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
