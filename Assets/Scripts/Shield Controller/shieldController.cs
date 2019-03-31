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
        if (other.gameObject.CompareTag("BlackBullet") || other.gameObject.CompareTag("BlueBullet") || other.gameObject.CompareTag("RedBullet"))
        {
            Destroy(other.gameObject); // this destroys the enemy
            this.numberOfHits--;
        }

    }
}
