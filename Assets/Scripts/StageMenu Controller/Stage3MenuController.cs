using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage3MenuController : MonoBehaviour
{
    private Animator anim; // board animation after level completed
    public Text txtScore;
    public static int score;

    void Start () 
    {
        anim = (GameObject.FindWithTag("levelCompleted")).GetComponent<Animator>();
    }

    void Update()
    {
        txtScore.text = "SCORE: " + score.ToString();

        if (score >= 140)
        {
            anim.SetBool("isFinished", true);
        }
    }

    public void NextGame()
    {
        BossMenuController.score = score;
        SceneManager.LoadScene("Boss");
    }

    // What happens when I click the quit button?
    public void QuitGame()
    {
        //score initialization
        HomingMissileScript.score = 0;
        Stage1MenuController.score = 0;
        Stage2MenuController.score = 0;
        score = 0;
        BossMenuController.score = 0;
        // Preprocessor Directives
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif
    }
}
