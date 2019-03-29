using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    //public GameObject wood;
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex){
                popUps[popUpIndex].SetActive(true);
            }
            else{
                popUps[popUpIndex].SetActive(false);
            }
        }        

        if(popUpIndex == 0){
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
                popUpIndex++;
            }
        } else if(popUpIndex == 1){
            if(Input.GetKey(KeyCode.W)){
                popUpIndex++;
            }
        } else if(popUpIndex == 2){
            if(Input.GetMouseButtonDown(0)){
                popUpIndex++;
            }
        }
    }
}
