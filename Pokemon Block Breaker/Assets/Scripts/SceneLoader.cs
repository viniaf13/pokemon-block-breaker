using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        //Get the build index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadPreviousScene()
    {
        //Get the build index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //Load the previous scene
        SceneManager.LoadScene(currentSceneIndex - 1);

    }

    public void LoadStartScene()
    {
        //Load the first scene
        SceneManager.LoadScene(0);

    }

    public void LoadLastScene()
    {
        //Load the last scene
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
