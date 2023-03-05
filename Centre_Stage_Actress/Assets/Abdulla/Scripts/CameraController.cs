using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float mouseSensivity = 2f;

    public GameObject sphere1;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private LayerMask obstacles;

    private float cameraUpDownRange = 60f;
    private float cameraRotationUpDown = 0;
    private float maxDistance;
    private Vector3 localPosition;
        
    private void Start() {
        localPosition = target.transform.InverseTransformPoint(transform.position);
        maxDistance = Vector3.Distance(transform.position, target.position);
    }

    void LateUpdate() {
        RotatingCameraUpDown();
        transform.position = target.TransformPoint(localPosition);
        ObstaclesReact();
    }

    private void RotatingCameraUpDown() {
        cameraRotationUpDown -= Input.GetAxis("Mouse Y") * mouseSensivity;
        cameraRotationUpDown = Mathf.Clamp(cameraRotationUpDown, -cameraUpDownRange, cameraUpDownRange);
        gameObject.transform.localRotation = Quaternion.Euler(cameraRotationUpDown, 0, 0);
    }

    private void ObstaclesReact() {
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, maxDistance, obstacles)) {
            transform.position = hit.point;
        } 
    }
}
