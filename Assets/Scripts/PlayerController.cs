using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 10.0f;

    // PRIVATE VARIABLES
    private Rigidbody2D rBody;

    // Reserved function. Runs only once when the object is created.
    // Used for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /* if(Input.GetKeyDown(KeyCode.Space)) // Listens to my space bar key being pressed
        {
            rBody.AddForce(new Vector2(0, jumpForce));
            canJump = false;
        } */

        // Raycast from your feet downwards towards the ground
        //Physics2D.Raycast()
    }

    /// <summary>
    /// this function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// Use FixedUpdate for Physics-based movement only
    /// </summary>

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(horiz, vert);

        //rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        rBody.velocity = new Vector2(horiz * speed, vert * speed);
    }
}
