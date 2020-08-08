using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        FindObjectOfType<GameSession>().SetCurrentLevel(currentSceneIndex + 1);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        FindObjectOfType<GameSession>().SetCurrentLevel(currentSceneIndex - 1);
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadLastLevel()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.ResetScore();
        int lastLevel = gameSession.GetCurrentLevel();
        SceneManager.LoadScene(lastLevel);
    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);
    }
    public void LoadLastScene()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.SetCurrentLevel(currentSceneIndex);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
