using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void ChangeScene(int sceneIndex)
    {
        //Allows changing between scenes both forward and back based upon buildsettings
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
        //Can use the quit game button to end the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}