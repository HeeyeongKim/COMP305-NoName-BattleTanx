using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Motor4Player2 : MonoBehaviour
{
    //public int health = 3;
    public float moveSpeed = 1;
    public float rotateSpeed = 12;
    public GameObject turret;
    //public Text healthText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //healthText.text = "Health: " + health.ToString();
    }

    void FixedUpdate()
    {
        float moveVector = Input.GetAxis("Vertical4Player2");
        float rotateVector = Input.GetAxis("Horizontal4Player2");

        this.transform.Translate(0f, moveVector * moveSpeed * Time.deltaTime, 0f);
        this.transform.Rotate(0f, 0f, rotateVector * (rotateSpeed * 10) * Time.deltaTime);
    }

    void Update()
    {
        TurretRotation();
    }

    void TurretRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - turret.transform.position.x, mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }

}
