using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
     public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
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
