using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject debrisPrefab;

    private Camera cam;
    private float cooldown = 0.2f;
    private float cooldownRemaining = 0;
    private float range = 100f;

    private Ray cameraTargetRay;
    private RaycastHit cameraHitInfo;
    private GameObject cameraHitObject;
    private Vector3 cameraHitPoint = Vector3.zero;

    private Ray playerTargetRay;
    private RaycastHit playerHitInfo;
    private GameObject playerHitObject;
    private Vector3 playerHitPoint = Vector3.zero;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        cooldownRemaining -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownRemaining <= 0) {
            cooldownRemaining = cooldown;

            cameraTargetRay = new Ray(cam.transform.position, cam.transform.forward); // Ray path

            if (Physics.Raycast(cameraTargetRay, out cameraHitInfo, range)) { // raycast ray in this range, save info
                cameraHitPoint = cameraHitInfo.point;
                cameraHitObject = cameraHitInfo.collider.gameObject;
            }
            
            playerTargetRay = new Ray(gameObject.transform.position, cameraHitInfo.point - gameObject.transform.position); // Ray second path
            
            if (Physics.Raycast(playerTargetRay, out playerHitInfo, range)) { // raycast ray in this range, save info
                playerHitPoint = playerHitInfo.point;
                playerHitObject = playerHitInfo.collider.gameObject;
            }

            if (cameraHitPoint == playerHitPoint) {
                Debug.Log("I can hit!");
            }

            if (debrisPrefab != null) { // Shooting Particle
                Instantiate(debrisPrefab, playerHitPoint, Quaternion.identity);
            }
        }
    }
}
