using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool wavesAreStillLooping = true;//bool to flip to false for when we want to stop looping waves
    [SerializeField] List<WaveConfigurationSO> waveConfigurations;
    [SerializeField] float timeBetweenWavesInSeconds = 0f;
    WaveConfigurationSO currentWave;//the current wave configuration
        public WaveConfigurationSO GetCurrentWave(){
            return currentWave;
        }

    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(SpawnEnemyWaves());

    }

    //Spawns each wave consecutively with a wait time in between waves(if a delay is added)
    private IEnumerator SpawnEnemyWaves(){
        //infinitley loops waves until "wavesAreStillLooping" is flipped to false
        do{
            //spawns each wave after the previous one has finished and delay time has been elapsed
            foreach(WaveConfigurationSO wave in waveConfigurations){
                currentWave = wave;
                //spawn all enemies in the current wave
                for (int i = 0; i < currentWave.GetEnemyCount(); i++){
                
                    Instantiate(
                        currentWave.GetEnemyPrefabAtIndex(i), 
                        currentWave.GetStartingWaypointOnEnemyPathPrefab().position, 
                        Quaternion.identity,
                        transform
                    );
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            yield return new WaitForSeconds(timeBetweenWavesInSeconds);
            }
            
            currentWave = waveConfigurations[0];
        }while(wavesAreStillLooping);
    }
}

