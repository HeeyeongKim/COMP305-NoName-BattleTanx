using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenuController : MonoBehaviour
{
    public void NextGame()
    {
        SceneManager.LoadScene("Stage1");

    }

    // What happens when I click the quit button?
    public void QuitGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
