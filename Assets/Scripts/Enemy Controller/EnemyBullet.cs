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
        if (other.gameObject.CompareTag("Player"))
        {
            int playerHealth = --other.gameObject.GetComponent<Motor>().health;
            other.gameObject.GetComponent<Motor>().healthText.text = "Health: " + playerHealth.ToString();

            if (playerHealth <= 0) {
                Debug.Log(other.gameObject.name);
                //Initialize score;
                HomingMissileScript.score = 0;
                Instantiate(explosionPref, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject); // this destroys the player
                SceneManager.LoadScene("GameOver");
            }
            Destroy(gameObject); // this destroys the bullet
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // this destroys the bullet
        }

    }

}
