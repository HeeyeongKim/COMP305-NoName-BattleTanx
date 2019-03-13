using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrierScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool movingRight = true;
    Vector3 localScale;

    //public GameObject explosion;
    public float boundaryX1;
    public float boundaryX2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > boundaryX1)
            movingRight = false;
        if(transform.position.x < boundaryX2)
            movingRight = true;
    }

    void FixedUpdate()
    {
        if(movingRight)
            moveRight();
        else
            moveLeft();
    }

    void moveRight()
    {
        localScale.x = -0.8f;
        transform.transform.localScale = localScale;
        rb.velocity = new Vector2(5,0);
    }

    void moveLeft()
    {
        localScale.x = 0.8f;
        transform.transform.localScale = localScale;
        rb.velocity = new Vector2(-5,0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        /** 
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(other.gameObject);  // this destroys the player
            Destroy(gameObject);
        }
        */
    }
}
