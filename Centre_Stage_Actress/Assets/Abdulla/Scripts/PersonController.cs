using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    public float mouseSensivity = 2f;
   

    private CharacterController characterController;
    private float cameraUpDownRange = 60f;
    private float cameraRotationUpDown = 0;
    private float characterRotationLeftRight;
    private float forwardSpeed;
    private float sideSpeed;
    private float jumpSpeed = 2.5f;
    private Vector3 speed;
    private float verticalVelocity = 0;
    private Camera cam;


    [SerializeField]
    private float movementSpeed = 2.5f;


    void Start() {
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        cam = Camera.main;
    }


    void Update() {
        RotatingCameraUpDown();
        MovingCharacter();
    }

    private void MovingCharacter() {

        characterRotationLeftRight = Input.GetAxis("Mouse X") * mouseSensivity;
        transform.Rotate(0, characterRotationLeftRight, 0); //Rotate whole character with camera view.

        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed; // W, S
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed; // A, D

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded && Input.GetButtonDown("Jump")) { // SPACE
            verticalVelocity = jumpSpeed;
        }

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed; //  Moving towards camera view.
        characterController.Move(speed * Time.deltaTime);

    }

    private void RotatingCameraUpDown() {
        
        cameraRotationUpDown -= Input.GetAxis("Mouse Y") * mouseSensivity;
        cameraRotationUpDown = Mathf.Clamp(cameraRotationUpDown, -cameraUpDownRange, cameraUpDownRange);
        cam.transform.localRotation = Quaternion.Euler(cameraRotationUpDown, 0, 0);

    }
}
