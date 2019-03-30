using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
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

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            if (this.gameObject.tag == "BlackBullet"){
                HealthBarScript.health -= 10f;
            } else if (this.gameObject.tag == "GreenBullet"){
                HealthBarScript.health -= 20f;
            }

            if (HealthBarScript.health <= 0) {
                HomingMissileScript.score = 0; // initialize score;
                Instantiate(explosionPref, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject); // destroys the player
                SceneManager.LoadScene("GameOver");
                Debug.Log("GameOver");
            }

            Destroy(gameObject); // this destroys the bullet

            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject); // destroys the bullet
            }

        }

    }
