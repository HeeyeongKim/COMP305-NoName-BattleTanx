﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomingMissileScript : MonoBehaviour
{
    GameObject target; // tutorial wood
    public GameObject explosionPref; // for tanks
    public GameObject explosionPref2; // for woods

    public float bulletSpeed;
    public float bulletDamage;
    public float maxTimeAlive;

    public static int score;
    private Text txt4score;

    private Animator anim; // board animation after level completed

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("targetWood");
        StartCoroutine(SelfDestruct());
        anim = (GameObject.FindWithTag("levelCompleted")).GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);    
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(maxTimeAlive);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("OnTriggerEnter2D method");

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
            SoundManagerScript.playSound("EnemyExplosion");
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            if(other.gameObject.CompareTag("Enemy")) 
            {
                score += 10;
                Stage1MenuController.score = score;
                Stage2MenuController.score = score;
                Stage3MenuController.score = score;
            }
            else if(other.gameObject.CompareTag("Enemy2"))
            {
                score += 20;
                Stage3MenuController.score = score;
            }
        } 
        else if(other.gameObject.CompareTag("Boss"))
        {
            score += 30;
            BossMenuController.score = score;
            BossHealthbarScript.health -= 10f;
            Destroy(this.gameObject);
            if (BossHealthbarScript.health <= 0)
            {
                Instantiate(explosionPref, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject); // this destroys the player
            }
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        } 
        else if (other.gameObject.CompareTag("Wood"))
        {
            SoundManagerScript.playSound("WoodExplosion");
            Destroy(gameObject); // destroys the bullet
            Instantiate(explosionPref2, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject); // destroys the wood
        }
        
        // Check if this is Player1 or Payer2
        if (this.gameObject.CompareTag("BulletRed"))
        {
            if(other.gameObject.CompareTag("Player2"))
                Destroy(this.gameObject);
        }
        else if (this.gameObject.CompareTag("BlueBullet"))
        {
             if(other.gameObject.CompareTag("Player"))
                Destroy(this.gameObject);
        }

        // Tutorial
        if (other.gameObject.CompareTag("targetWood"))
        {
            SoundManagerScript.playSound("EnemyExplosion");
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            anim.SetBool("isFinished", true);
        }
    }

    void pauseGame() {
        Time.timeScale = 0;
    }
}
