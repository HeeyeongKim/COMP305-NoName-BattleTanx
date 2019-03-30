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
        currentScene = SceneManager.GetActiveScene();
        //Debug.Log(currentScene.name);

        target = GameObject.Find("targetWood");

        StartCoroutine(SelfDestruct());

        if (currentScene.name.Equals("Stage1"))
        {
            txt4score = (GameObject.FindWithTag("Score")).GetComponent<Text>();
        }

    /*     if (currentScene.name.Equals("Stage1"))
        {
            anim = (GameObject.FindWithTag("stage1menu")).GetComponent<Animator>();
        } */

        anim = (GameObject.FindWithTag("levelCompleted")).GetComponent<Animator>();
    }

    void Update()
    {
        if (currentScene.name.Equals("Stage1"))
        {
            txt4score.text = score + " / 3";
        }

        if (currentScene.name.Equals("Stage1") && score == 3)
        {
            anim.SetBool("isFinished", true);
        }
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            score = score + 1;
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

            anim.SetBool("isFinished", true);
        }
    }

    void pauseGame() {
        Time.timeScale = 0;
    }
}
