using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipScript : MonoBehaviour
{

    //player movement
    [SerializeField] private float movementSpeed; //movement speed multiplier
    private Vector2 rawMoveInputVector; //raw movement input
        private Vector3 upcomingMovementVector; //movement adjusted for frame rate + movement speed
    


    //player boundaries
        [SerializeField] float boundaryPaddingX;
        [SerializeField] float boundaryPaddingY;
        Vector2 minimumPlayerMapBoundary;
        Vector2 maximumPlayerMapBoundary;

        //Initialize player boundaries using main camera viewport values
        private void InitiatePlayerBoundaryValues() {
            Camera mainCamera = Camera.main;
            minimumPlayerMapBoundary = mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
            maximumPlayerMapBoundary = mainCamera.ViewportToWorldPoint(new Vector2 (1,1));
        }

    ProjectileShooter shooterScript;
    private void Awake(){
        shooterScript = GetComponent<ProjectileShooter>();
    }
    private void Start() {
        InitiatePlayerBoundaryValues();
    }

    // Update is called once per frame
    private void Update() {
        PlayerMovement();
    }

    /*
        executes player movement each frame:
        1.multiplies the raw input vector by framerate and movement speed multiplier and applies it to upcoming movement
        2.ensures the upcoming movement doesn't take the upcoming position outside of the boundaries of the viewport space using Math.Clamp(value, minValue, maxValue)
        3.applies that new position to the player
    */
    private void PlayerMovement() {
        upcomingMovementVector = rawMoveInputVector * movementSpeed * Time.deltaTime;
        
        Vector2 upComingPosition = new Vector2();
        upComingPosition.x = Math.Clamp(transform.position.x + upcomingMovementVector.x, minimumPlayerMapBoundary.x + boundaryPaddingX, maximumPlayerMapBoundary.x - boundaryPaddingX);
        upComingPosition.y = Math.Clamp(transform.position.y + upcomingMovementVector.y, minimumPlayerMapBoundary.y + boundaryPaddingY, maximumPlayerMapBoundary.y - boundaryPaddingY);
        
        transform.position = upComingPosition;
    }

            //get the raw movement input value from the player input component
    private void OnMove(InputValue value) {
        rawMoveInputVector = value.Get<Vector2>();
    }
    private void OnFire(InputValue value){
        if (shooterScript != null){
            shooterScript.isFiring = value.isPressed;
        }
    }
}
