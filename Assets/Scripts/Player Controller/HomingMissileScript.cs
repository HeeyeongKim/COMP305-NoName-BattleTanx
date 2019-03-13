using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileScript : MonoBehaviour
{
    GameObject target;
    public GameObject explosion;
    public float rotationSpeed = 1f;

    Quaternion rotateToTarget;
    Vector3 dir;

    Rigidbody2D rb;

    public float bulletSpeed;
    public float bulletDamage;
    public float maxTimeAlive;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("targetWood");
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(SelfDestruct());
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
        Debug.Log("OnTriggerEnter2D method");

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("targetWood!!");

            //Destroy(other.gameObject); // this destroys the enemy
            //Destroy(gameObject); // this destroys the bullet

            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
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
