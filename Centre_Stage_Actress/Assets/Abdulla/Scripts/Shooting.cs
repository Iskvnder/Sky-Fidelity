using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject debrisPrefab;

    private Camera cam;
    private float bulletImpulse = 10f;
    private float cooldown = 0.2f;
    private float cooldownRemaining = 0;
    private float range = 100f;


    void Start() {
        cam = Camera.main;
    }


    void Update() {
        cooldownRemaining -= Time.deltaTime;

        //if (Input.GetButtonDown("Fire1")) {
        //    GameObject bullet = Instantiate(bulletPrefab, cam.transform.position + cam.transform.forward * 0.4f, cam.transform.rotation);
        //    bullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * bulletImpulse, ForceMode.Impulse);
        //}

        if (Input.GetButton("Fire1") && cooldownRemaining <= 0) {
            cooldownRemaining = cooldown;

            Ray cameraTargetRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit cameraHitInfo;
            GameObject cameraTargetObject;
            Vector3 cameraHitPoint;

            Physics.Raycast(cameraTargetRay, out cameraHitInfo);
            cameraHitPoint = cameraHitInfo.point;
            cameraTargetObject = cameraHitInfo.collider.gameObject;

            Debug.Log("Hit object: " + cameraTargetObject.name);
            Debug.Log("Hit point: " + cameraHitPoint);

            Ray playerTargetRay = new Ray(gameObject.transform.position, cameraHitInfo.point - gameObject.transform.position);
            RaycastHit playerHitInfo;
            GameObject playerTargetObject;
            Vector3 playerHitPoint;

            Physics.Raycast(playerTargetRay, out playerHitInfo);
            playerHitPoint = playerHitInfo.point;
            playerTargetObject = playerHitInfo.collider.gameObject;

            Debug.Log("Hit object2: " + playerTargetObject.name);
            Debug.Log("Hit point2: " + playerHitPoint);

            if (cameraHitPoint == playerHitPoint) {
                Debug.Log("I can hit!");
            }
        }
    }
}
