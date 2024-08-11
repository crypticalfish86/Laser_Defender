using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{   
    [Header("General attributes")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float timeBetweenShots = 0.2f;
    [Header("Attributes for enemy Ai")]
    [SerializeField] bool useAutomatedFiring;
    [SerializeField] float enemyFireRateVariability = 0.5f;
    [SerializeField] float minimumEnemyTimeBetweenShots = 0.2f;

    public bool isFiring;

    Coroutine firingCoroutine;//A variable to store our coroutine (for us to check if one is active or not in our code)
    
    // Start is called before the first frame update
    void Start()
    {
        if(useAutomatedFiring){
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FireProjectile();
    }

    /*
        If is firing bool is flipped true and a firingCoroutine doesn't exist, start a coroutine
        else if firing bool is flipped false and a firingCoroutine exists stop the coroutine
    */
    private void FireProjectile(){
        if (isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously(){
        while (isFiring){
            GameObject instance =
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D myRigidBody = instance.GetComponent<Rigidbody2D>();
            if (myRigidBody != null){
                if (useAutomatedFiring){
                    myRigidBody.velocity = new Vector3 (0, -1  * projectileSpeed, 0);
                }
                else {
                    myRigidBody.velocity = transform.up * projectileSpeed;//uses the global "up direction" as a vector3 variable (the value of this is always (0,1,0))
                }
            }
            Destroy(instance, projectileLifetime);
            //if gameObject is an enemy ai then add variability to shot time to add level of randomness, otherwise its the player which has a consistent fire rate
            if (useAutomatedFiring){
                float randomTimeBetweenShots = Random.Range(timeBetweenShots - enemyFireRateVariability, timeBetweenShots + enemyFireRateVariability);
                //ensure the time between shots doesn't go below a certain minimum rate
                if (randomTimeBetweenShots < minimumEnemyTimeBetweenShots){
                    randomTimeBetweenShots = minimumEnemyTimeBetweenShots;
                } 
                yield return new WaitForSeconds(randomTimeBetweenShots);
            }
            else {
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }
    }
}
