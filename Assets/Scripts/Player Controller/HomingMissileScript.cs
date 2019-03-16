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

    private static int score;
    public Text txt4score;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("targetWood");
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(SelfDestruct());

        if (GameObject.FindWithTag("Score") != null)
        {
            txt4score = (GameObject.FindWithTag("Score")).GetComponent<Text>();
        }

        if (GameObject.FindWithTag("stage1menu") != null)
        {
            anim = (GameObject.FindWithTag("stage1menu")).GetComponent<Animator>();
        }
        

    }

    void Update()
    {
        //Debug.Log(score);
        if (txt4score != null)
        {
            txt4score.text = score + " / 3";
        }

        if (score == 3)
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
            //Debug.Log("targetWood!!");

            //Destroy(other.gameObject); // this destroys the enemy
            //Destroy(gameObject); // this destroys the bullet

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

            SceneManager.LoadScene("Stage1");
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
