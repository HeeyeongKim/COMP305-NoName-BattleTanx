using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public float spawnTimeSec;
    public GameObject shieldItem;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateShieldItem", spawnTimeSec);
        //CreateShieldItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateShieldItem() {
        Vector3 position = new Vector3(Random.Range(-1, 1),Random.Range(-1, 1), 0);
        Instantiate(shieldItem, position, Quaternion.identity);
    }
}
