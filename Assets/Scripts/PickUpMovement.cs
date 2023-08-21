using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMovement : MonoBehaviour {

    [Header("Environment Variables")]
    public float xBorderMin = -1.2f;
    public float xBorderMax = 1.2f;
    public float yBorderMin = 1.3f;
    public float yBorderMax = 2.9f;
    public float zBorderMin = 0.8f;
    public float zBorderMax = 2.2f;
     

    public CharacterController controller;
	
    public Vector3 velocity;
    public float speed = 1f;
    public float ySpeed = 20f;

    void Update() {
        if (CheckIfInBorders()) {
            float x = Input.GetAxis("Mouse X");
            float z = Input.GetAxis("Mouse Y");
            float y = Input.GetAxis("Mouse ScrollWheel");
            
            Vector3 move = transform.right * x + transform.forward * z;
            Vector3 moveY = transform.up * y;
            controller.Move(moveY * ySpeed * Time.deltaTime);
            controller.Move(move * speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z);
        }
        else {
            CorrectPos();
        }
        
    }

    bool CheckIfInBorders() {
        if (transform.position.z>=zBorderMin && transform.position.z<=zBorderMax && transform.position.x>=xBorderMin && transform.position.x<=xBorderMax && transform.position.y >= yBorderMin && transform.position.y <= yBorderMax) {
            return true;
        }
        return false;
    }

    void CorrectPos() {
        if (transform.position.z<zBorderMin) {
            transform.position = new Vector3(transform.position.x , transform.position.y, zBorderMin);
        }
        if (transform.position.z>zBorderMax) {
            transform.position = new Vector3(transform.position.x , transform.position.y, zBorderMax);
        }
        if (transform.position.x<xBorderMin) {
            transform.position = new Vector3(xBorderMin , transform.position.y, transform.position.z);
        }
        if (transform.position.x>xBorderMax) {
            transform.position = new Vector3(xBorderMax , transform.position.y, transform.position.z);
        }
        if (transform.position.y < yBorderMin)
        {
            transform.position = new Vector3(transform.position.x, yBorderMin, transform.position.z);
        }
        if (transform.position.y > yBorderMax)
        {
            transform.position = new Vector3(transform.position.x, yBorderMax, transform.position.z);
        }
    }
}
