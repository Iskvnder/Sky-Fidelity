using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public Image aim;

    [SerializeField]
    private GameObject debrisPrefab;
    [SerializeField]
    private Transform debugTransform;
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject aimCamera;

    private float cooldown = 0.2f;
    private float cooldownRemaining = 0;
    private float range = 100f;
    private Camera cam;
    private RaycastHit playerHitInfo;
    private Vector2 screenCenterPoint;


    void Start() {
        cam = Camera.main;
    }

    void Update() {
        Aim();
        Shoot();
    }

    void Aim() {
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);

        if (Input.GetButton("Fire2")) {
            aim.enabled = true;
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
        } else {
            aim.enabled = false;
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
        }
    }

    void Shoot() {
        cooldownRemaining -= Time.deltaTime;

        if (Input.GetButton("Fire2")) {

            if (Input.GetButton("Fire1") && cooldownRemaining <= 0) {
                cooldownRemaining = cooldown;

                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
                if (Physics.Raycast(ray, out playerHitInfo, range)) {
                    debugTransform.position = playerHitInfo.point;
                }

                if (debrisPrefab != null) { // Shooting Particle
                    Instantiate(debrisPrefab, playerHitInfo.point, Quaternion.identity);
                }
            }
        } 
    }
}
