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

    [SerializeField] WaveConfigurationSO waveConfiguration;
        private List<Transform> waypoints;
        private int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfiguration.GetAllWaypointsOnEnemyPathPrefab();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPresetPath();
    }

    //make the enemy move along the preset path by the scriptable object until final waypoint where it despawns
    private void FollowPresetPath() {
        if (waypointIndex < waypoints.Count) {
            float deltaVelocityPerFrame = waveConfiguration.GetEnemyMovementSpeed() * Time.deltaTime;
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
