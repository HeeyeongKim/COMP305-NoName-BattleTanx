using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3MenuController : MonoBehaviour
{
    public void NextGame()
    {
        SceneManager.LoadScene("Boss");
    }

    // What happens when I click the quit button?
    public void QuitGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
