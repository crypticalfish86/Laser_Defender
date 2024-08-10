using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigurationSO currentWave;//the current wave configuration
        public WaveConfigurationSO GetCurrentWave(){
            return currentWave;
        }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    //Instantiates/spawns enemies as children of enemy spawner
    private IEnumerator SpawnEnemies(){
        for (int i = 0; i < currentWave.GetEnemyCount(); i++){
            
            Instantiate(
                currentWave.GetEnemyPrefabAtIndex(i), 
                currentWave.GetStartingWaypointOnEnemyPathPrefab().position, 
                Quaternion.identity,
                transform
            );
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }
    }
}
