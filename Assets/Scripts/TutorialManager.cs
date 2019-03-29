using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    
    // Update is called once per frame
    void Update()
    {
        // popUps[0]: press space bar
        // popUps[1]: press A,D
        // popUps[2]: press W,S
        // popUps[3]: press left mouse button
        // popUps[4]: hit the target

        if(popUpIndex == 0){
            if(Input.GetKeyDown(KeyCode.Space)){
                popUps[0].SetActive(false);
                popUps[1].SetActive(true);
                popUpIndex++;
            }
        } else if(popUpIndex == 1){
             if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
                popUps[1].SetActive(false);
                popUps[2].SetActive(true);
                popUpIndex++;
            }
        } else if(popUpIndex == 2){
             if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
                popUps[2].SetActive(false);
                popUps[3].SetActive(true);
                popUpIndex++;
            }
        } else if(popUpIndex == 3){
            if(Input.GetMouseButtonDown(0)){
                popUps[3].SetActive(false);
                popUps[4].SetActive(true);
                popUpIndex++;
            }
        } else if(popUpIndex == 4 && Input.GetMouseButtonDown(0)){
            popUps[4].SetActive(false);
        }
    }
}
