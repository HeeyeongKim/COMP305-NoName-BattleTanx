using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{
    public int numberOfHits;
    public GameObject champion;
    // Start is called before the first frame update
    void Start()
    {
        numberOfHits = 3;
         Physics2D.IgnoreCollision(champion.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = champion.transform.position;
        if (this.numberOfHits <= 0) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BlackBullet"))
        {
            Destroy(other.gameObject); // this destroys the enemy bullet
            this.numberOfHits--;
        } 
        if(champion.CompareTag("Player")) {
            if (other.gameObject.CompareTag("BlueBullet"))
            {
                Destroy(other.gameObject); // this destroys the another players bullet
            } 
        }
        if(champion.CompareTag("Player2")) {
            if (other.gameObject.CompareTag("BulletRed"))
            {
                Destroy(other.gameObject); // this destroys the another players bullet
            } 
        }

    }
}
