using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class HomingMissileScript : MonoBehaviour
{
    GameObject target;
    public GameObject explosionPref;
    public float rotationSpeed = 1f;

    Quaternion rotateToTarget;
    Vector3 dir;

    Rigidbody2D rb;

    public float bulletSpeed;
    public float bulletDamage;
    public float maxTimeAlive;

    public static int score;
    public Text txt4score;

    private Animator anim;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        //Debug.Log(currentScene.name);

        target = GameObject.Find("targetWood");
        rb = GetComponent<Rigidbody2D>();

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
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("targetWood"))
        {
            Instantiate(explosionPref, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            anim.SetBool("isFinished", true);

            //SceneManager.LoadScene("Stage1");
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        //Debug.Log("Update method");

        //dir = (target.transform.position - transform.position).normalized;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //rotateToTarget = Quaternion.Slerp(transform.rotation, rotateToTarget,
        //    Time.deltaTime * rotationSpeed);
        //rb.velocity = new Vector2(dir.x*2, dir.y*2);
    //}
/** 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D method");

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(target);
    }
*/

}
