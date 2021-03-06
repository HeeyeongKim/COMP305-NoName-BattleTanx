﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed;
    public float bulletDamage;
    public float maxTimeAlive;
    public GameObject explosionPref;

    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);    
    }

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(maxTimeAlive);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPref, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject); // this destroys the enemy
            Destroy(gameObject); // this destroys the bullet
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // this destroys the bullet
        }

    }
}
