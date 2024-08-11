using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthAndDamage : MonoBehaviour
{
    [SerializeField] int shipHealth = 50;
    [SerializeField] int shipDamageOutput = 10;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (gameObject.tag == "Enemy" && other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<ShipHealthAndDamage>().TakeDamage(shipDamageOutput * 3);
            Destroy(gameObject);
        }
    }

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
