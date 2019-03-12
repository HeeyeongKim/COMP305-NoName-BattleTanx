using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnerScript : MonoBehaviour
{
    public GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(missile, mousePos, Quaternion.Euler(0,0,90));
        }
    }
}
