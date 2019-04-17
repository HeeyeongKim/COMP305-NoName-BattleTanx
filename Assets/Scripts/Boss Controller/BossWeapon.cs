using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    
    public float fireRate = 10;

    //float timeUntilFire = 0;

    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bullet;
    public float nextTime;

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
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }
}
