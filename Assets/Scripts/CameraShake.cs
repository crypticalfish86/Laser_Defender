using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float secondsToShakeFor = 0.5f;
    [SerializeField] float shakeStrength = 0.5f;

    Vector3 initialPositionOfCamera;
    void Start()
    {
        initialPositionOfCamera = transform.position;
    }

    public void Play(){
        StartCoroutine(Shake());
    }

    //insideUnitCircle gives a random position in a circle of radius size 1 unity unit that we are using to shake the camera
    IEnumerator Shake(){
        float timer = 0;
        while(timer < secondsToShakeFor){
            transform.position = initialPositionOfCamera + (Vector3)Random.insideUnitCircle * shakeStrength;
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPositionOfCamera;
    }

    void Update()
    {
        
    }
}
