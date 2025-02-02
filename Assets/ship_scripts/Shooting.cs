using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private game_manager manager;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;

    private float nextFireTime = 0.0f;

    private void Start() {
        manager = FindObjectOfType<game_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.in_build_mode) {
            //checks that the next fire time has been reached before firing again
            if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime) {
                Fire();
                nextFireTime = Time.time + 1.0f / fireRate;
            }
        }
    }

    void Fire() {
        //creates an instance of the bullet prefab and adds velocity bulletspeed, bullet destroyed after 2 seconds to avoid clutter
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 2f);
    }
}
