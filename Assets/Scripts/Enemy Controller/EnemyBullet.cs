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
            //When the player 1 is shot, reduce the value of its health bar
            if (other.gameObject.CompareTag("Player"))
            {
                if (this.gameObject.tag == "BlackBullet"){
                    HealthBarScript.health -= 10f;
                } else if (this.gameObject.tag == "GreenBullet"){
                    HealthBarScript.health -= 20f;
                }
                
                //When the value of health bar is less than zero, remove the player 1 gameobject.
                if (HealthBarScript.health <= 0)
                {
                    Debug.Log(other.gameObject.name);

                    Instantiate(explosionPref, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject); // this destroys the player

                }
            }
            //When the player 2 is shot, reduce the value of its health bar
            else if(other.gameObject.CompareTag("Player2"))
            {
                if (this.gameObject.tag == "BlackBullet"){
                    HealthBarScript4Player2.health -= 10f;
                } else if (this.gameObject.tag == "GreenBullet"){
                    HealthBarScript4Player2.health -= 20f;
                }

                if (HealthBarScript4Player2.health <= 0)
                {
                    Debug.Log(other.gameObject.name);

                    Instantiate(explosionPref, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject); // destroys the player

                }
            }

             //When both tanks are destroyed, the game ends.
            if ((GameObject.FindWithTag("Player") == null || HealthBarScript.health <= 0)
                && (GameObject.FindWithTag("Player2") == null || HealthBarScript4Player2.health <= 0))
            {
                //Initialize score;
                HomingMissileScript.score = 0;
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
