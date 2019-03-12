using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public float fireRate = 10;

    //float timeUntilFire = 0;

    public Transform firePoint;
    public GameObject bullet;
    public float nextTime;
    public GameObject turret;

    void Update()
    {
        //if(Time.time > timeUntilFire)
        //{ 
        //    timeUntilFire = Time.time + 1 / fireRate;
        //    Shoot();
        //}
        if (Time.time > nextTime)
        {
            Shoot();
            nextTime = Time.time + 2;

        }
    }



    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
