using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Image aim;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject debrisPrefab;

    private Camera cam;
    private float cooldown = 0.2f;
    private float cooldownRemaining = 0;
    private float range = 100f;

    private RaycastHit cameraHitInfo;
    private RaycastHit playerHitInfo;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        cooldownRemaining -= Time.deltaTime;

        cameraHitInfo = CreateRay(cam.transform.position + cam.transform.forward * 0.2f, cam.transform.forward);
        playerHitInfo = CreateRay(gameObject.transform.position, cameraHitInfo.point - gameObject.transform.position);
        
        if (playerHitInfo.collider != null && playerHitInfo.collider.gameObject.tag == "Enemy") {
            aim.color = Color.green;
        } else {
            aim.color = Color.red;
        }

        if (Input.GetButton("Fire1") && cooldownRemaining <= 0) {
            cooldownRemaining = cooldown;

            if (debrisPrefab != null) { // Shooting Particle
                Instantiate(debrisPrefab, playerHitInfo.point, Quaternion.identity);
            }
        }
    }

    private RaycastHit CreateRay(Vector3 position, Vector3 direction) {
        Ray targetRay = new Ray(position, direction);
        RaycastHit hitInfo;
        Physics.Raycast(targetRay, out hitInfo, range);
        return hitInfo;
    }
}
