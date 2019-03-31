using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject); 
            shield.GetComponent<shieldController>().champion = other.gameObject;
            Instantiate(shield, other.transform.position, other.transform.rotation);
        } 

    }
}
