using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon4Player2 : MonoBehaviour
{

    public float fireRate = 3;

    float timeUntilFire = 0;

    public Transform firePoint;
    public GameObject bullet;


    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Time.time > timeUntilFire)
        {
            timeUntilFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
