using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float timeBetweenShots = 0.2f;
    [SerializeField] bool useAutomatedFiring;

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
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
