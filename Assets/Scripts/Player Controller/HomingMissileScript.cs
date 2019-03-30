using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomingMissileScript : MonoBehaviour
{
    GameObject target; // tutorial wood
    public GameObject explosionPref;

    public float bulletSpeed;
    public float bulletDamage;
    public float maxTimeAlive;

    public static int score;
    private Text txt4score;

    private Animator anim; // board animation after level completed

    private Scene currentScene;

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
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2"))
        {
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
            if(other.gameObject.CompareTag("Enemy2"))
            {
                score += 20;
                Stage3MenuController.score = score;
            }
        } 
    
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        // Tutorial
        if (other.gameObject.CompareTag("targetWood"))
        {
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameFinished();
        }
    }

    public void GameFinished(){
        anim.SetBool("isFinished", true);
    }

    void PauseGame() {
        Time.timeScale = 0;
    }

}
