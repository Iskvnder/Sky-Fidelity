using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float mouseSensivity = 2f;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private LayerMask obstacles;

    private float cameraUpDownRange = 60f;
    private float cameraRotationUpDown = 0;
    private float maxDistance;
    private Vector3 localPosition;
    private Vector3 zoomPosition;
        
    private void Start() {
        localPosition = target.transform.InverseTransformPoint(transform.position);
        zoomPosition = localPosition + transform.forward * 0.6f;
        maxDistance = Vector3.Distance(transform.position, target.position);
    }

    void LateUpdate() {
        RotatingCameraUpDown();
        Zooming();
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

    private void Zooming() {
        if (Input.GetButton("Fire2")) {
            transform.position = target.TransformPoint(zoomPosition);
        } else {
            transform.position = target.TransformPoint(localPosition);
        }
    }
}
