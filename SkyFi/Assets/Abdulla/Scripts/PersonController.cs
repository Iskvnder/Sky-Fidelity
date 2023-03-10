using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

    public float mouseSensivity = 2f;
    public Transform aim;

    private CharacterController characterController;

    private float movementSpeed = 2.5f;
    private float gravity = -9.81f;
    private float jumpHeight = 0.5f;

    private float characterRotationLeftRight;
    private float characterRotationUpDown;
    private float upDownRange = 30.0f;

    private float vertical;
    private float horizontal;
    private float velocityY = 0;
    private Vector3 direction;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();
    }


    void Update() {
        MovingCharacter();
    }

    private void MovingCharacter() {
        vertical = Input.GetAxis("Vertical") * movementSpeed; // W, S
        horizontal = Input.GetAxis("Horizontal") * movementSpeed; // A, D

        if (Input.GetKey(KeyCode.LeftShift)) {
            movementSpeed = 2.2f;
        } else {
            movementSpeed = 1.5f;
        }

        if (characterController.isGrounded && velocityY < 0) {
            velocityY = -2f;
        }

        characterRotationLeftRight = Input.GetAxis("Mouse X") * mouseSensivity;
        transform.Rotate(0, characterRotationLeftRight, 0); //Rotate whole character with camera view.

        characterRotationUpDown -= Input.GetAxis("Mouse Y") * mouseSensivity;
        characterRotationUpDown = Mathf.Clamp(characterRotationUpDown, -upDownRange, upDownRange);
        aim.localRotation = Quaternion.Euler(characterRotationUpDown, 0, 0);

        velocityY += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && characterController.isGrounded) {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        direction = new Vector3(horizontal, velocityY, vertical);

        direction = transform.rotation * direction; //  Moving towards camera view.
        characterController.Move(direction * Time.deltaTime);


    }

}
