using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFiring;

    Coroutine firingCoroutine;//note
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireProjectile();
    }

    private void FireProjectile(){
        if (isFiring && firingCoroutine == null){//note
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);//note
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously(){
        while (isFiring){
            GameObject instance =
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D myRigidBody = instance.GetComponent<Rigidbody2D>();
            if (myRigidBody != null){
                myRigidBody.velocity = transform.up * projectileSpeed;//note
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
