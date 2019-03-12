using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrierScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool movingRight = true;
    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7)
            movingRight = false;
        if(transform.position.x < -7)
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
        localScale.x = -1;
        transform.transform.localScale = localScale;
        rb.velocity = new Vector2(5,0);

    }

    void moveLeft()
    {
        localScale.x = 1;
        transform.transform.localScale = localScale;
        rb.velocity = new Vector2(-5,0);

    }
}
