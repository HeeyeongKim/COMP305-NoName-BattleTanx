using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1MenuController : MonoBehaviour
{
    public void NextGame()
    {
        //initialize score
        HomingMissileScript.score = 0;
        SceneManager.LoadScene("Stage2");

    }

    // What happens when I click the quit button?
    public void QuitGame()
    {
        //initialize score
        HomingMissileScript.score = 0;
        SceneManager.LoadScene("GameOver");
    }
}
