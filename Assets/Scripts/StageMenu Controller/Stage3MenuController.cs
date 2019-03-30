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
        // Preprocessor Directives
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif
    }
}
