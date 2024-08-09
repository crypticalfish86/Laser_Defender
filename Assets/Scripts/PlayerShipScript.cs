using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipScript : MonoBehaviour
{

    //player movement
    [SerializeField] private float movementSpeed; //movement speed multiplier
    private Vector2 rawMoveInputVector; //raw movement input
        private Vector3 adjustedMovementVector; //movement adjusted for frame rate + movement speed
    
        //get the raw movement input value from the player input component
        private void OnMove(InputValue value) {
            rawMoveInputVector = value.Get<Vector2>();
        }


    // Update is called once per frame
    private void Update() {
        PlayerMovement();
    }

    //adjust movement by frame rate and movementspeed multiplier and then move player
    private void PlayerMovement() {
        adjustedMovementVector = rawMoveInputVector * movementSpeed * Time.deltaTime;
        transform.position += adjustedMovementVector;
    }
}
