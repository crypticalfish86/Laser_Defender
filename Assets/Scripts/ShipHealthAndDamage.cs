using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthAndDamage : MonoBehaviour
{
    [SerializeField] int shipHealth = 50; //health of the ship
        public int GetShipHealth(){
            return shipHealth;
        }
    [SerializeField] int objectDamageOutput = 10; //the amount of damage this ship object does
    [SerializeField] ParticleSystem hitEffect;
    
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void Start() {
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
    }

    //When colliding with another trigger, damage the object associated with that trigger 
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<ShipHealthAndDamage>().TakeDamage(objectDamageOutput);
    }

    //damage this object, if health drops to 0, destroy the object and update score if enemy was destroyed
    private void TakeDamage(int damageAmount){
        PlayHitEffect();
        Debug.Log("hit");
        if (shipHealth - damageAmount < 0){
            Destroy(gameObject);
            //if the thing bullet collided with was an enemy update score
            if (gameObject.tag == "Enemy"){
                FindFirstObjectByType<ScoreKeeper>().UpdateScore(100);
            }
        }
        else {
            shipHealth -= damageAmount;
        }
    }

    private void PlayHitEffect(){
        if (gameObject.tag == "Player"){
            audioPlayer.PlayDamageClip();
            cameraShake.Play();
        }
        if(hitEffect != null){
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
