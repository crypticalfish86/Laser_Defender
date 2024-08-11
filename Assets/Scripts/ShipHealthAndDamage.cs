using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthAndDamage : MonoBehaviour
{
    [SerializeField] int shipHealth = 50;
    [SerializeField] int objectDamageOutput = 10;
    

    //When colliding with another trigger, damage the object associated with that trigger
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<ShipHealthAndDamage>().TakeDamage(objectDamageOutput);
    }

    //damage this object, if health drops to 0, destroy the object
    private void TakeDamage(int damageAmount){
        Debug.Log("hit");
        if (shipHealth - damageAmount < 0){
            Destroy(gameObject);
        }
        else {
            shipHealth -= damageAmount;
        }
    }
}
