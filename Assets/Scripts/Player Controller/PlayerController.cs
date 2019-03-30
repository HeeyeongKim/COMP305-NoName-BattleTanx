using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 3.0f;
    public float rotspeed = 150.0f;
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
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(0, -speed * Time.deltaTime));
            if (Input.GetKey(KeyCode.A))
                transform.Rotate(new Vector3(0, 0, -rotspeed * Time.deltaTime));
            if (Input.GetKey(KeyCode.D))
                transform.Rotate(new Vector3(0, 0, rotspeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, rotspeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(0, 0, -rotspeed * Time.deltaTime));
        }


    }


    /// <summary>
    /// this function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// Use FixedUpdate for Physics-based movement only
    /// </summary>

    void FixedUpdate()
    {

    }

}