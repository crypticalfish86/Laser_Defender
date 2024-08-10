using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    This script is for the pathfindings of enemies in an enemy wave.
    It will spawn in on the first waypoint of the path we have prescribed in our scriptable object
    and then move to each waypoint and despawn on the last waypoint
*/
public class Pathfinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;//The associated enemyspawner
    private WaveConfigurationSO waveConfiguration;//the current wave configuration
        private List<Transform> waypoints;//a list of waypoints for the pathfinding to use
        private int waypointIndex = 0;//the index to iterate through the waypoints

    
    //Associate the (only) spawner with this object on awake
    private void Awake() {
        enemySpawner = FindFirstObjectByType<EnemySpawner>(); 
    }

    // Start is called before the first frame update
    private void Start()
    {
        waveConfiguration = enemySpawner.GetCurrentWave();
        waypoints = waveConfiguration.GetAllWaypointsOnEnemyPathPrefab();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    private void Update()
    {
        FollowPresetPath();
    }

    //make the enemies this wave move along the preset path by the scriptable object until final waypoint where they despawn
    private void FollowPresetPath() {
        //If there are still enemies to set on paths keep setting them, otherwise destroy this script as its served its purpose
        if (waypointIndex < waypoints.Count) {
            float deltaVelocityPerFrame = waveConfiguration.GetEnemyMovementSpeed() * Time.deltaTime; //make the movement frame rate independent
            Vector3 targetPosition = waypoints[waypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, deltaVelocityPerFrame);
            if (transform.position == targetPosition){
                waypointIndex++;
            } 
        }
        else {
            Destroy(gameObject);
        }
    }
}
