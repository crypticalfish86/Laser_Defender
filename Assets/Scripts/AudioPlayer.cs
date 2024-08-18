using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingAudio;
    [SerializeField] [Range(0f, 1f)]float shootingAudioVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageAudio;
    [SerializeField] [Range(0f, 1f)] float damageAudioVolume = 1f;


    private void Awake() {
        ManageSingleton();
    }

    private void ManageSingleton(){
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShootingClip(){
        if (shootingAudio != null){
            AudioSource.PlayClipAtPoint(shootingAudio, Camera.main.transform.position, shootingAudioVolume);
        }
    }

    public void PlayDamageClip(){
        if (damageAudio != null) {
            AudioSource.PlayClipAtPoint(damageAudio, Camera.main.transform.position, damageAudioVolume);
        }
    }

}
