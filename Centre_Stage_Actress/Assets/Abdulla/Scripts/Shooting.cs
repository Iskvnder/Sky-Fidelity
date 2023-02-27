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
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, range)) {
                Vector3 hitPoint = hitInfo.point;
                GameObject go = hitInfo.collider.gameObject;

                Debug.Log("Hit object " + go.name);
                Debug.Log("Hit point: " + hitPoint);

                if (debrisPrefab != null) {
                    Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
                }
            }
        }
    }
}
