using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float moveSpeed = 1;
    public float rotateSpeed = 12;
    public GameObject turret;

    void FixedUpdate()
    {
        float moveVector = Input.GetAxis("Vertical");
        float rotateVector = Input.GetAxis("Horizontal");

        this.transform.Translate(0f, moveVector * moveSpeed * Time.deltaTime, 0f);
        this.transform.Rotate(0f, 0f, rotateVector * (rotateSpeed * 10) * Time.deltaTime);
    }

    void Update()
    {
        TurrentRotation();
    }

    void TurrentRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - turret.transform.position.x, mousePosition.y - turret.transform.position.y);

        turret.transform.up = direction;
    }

}
