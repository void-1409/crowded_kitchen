using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10.0f;
    private bool isWalking = false;

    void Start() {
        
    }

    private void Update() {

        // Getting input from user
        Vector2 inputVector = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1f;
        }

        inputVector = inputVector.normalized;

        // Moving Player Object
        Vector3 movement = new Vector3(-inputVector.y, 0f, inputVector.x);
        transform.position += movement * playerSpeed * Time.deltaTime;
        
        isWalking = movement != Vector3.zero;

        // Making Player Rotate Smoothly
        transform.forward = Vector3.Slerp(transform.forward, movement, Time.deltaTime * playerSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }
}
