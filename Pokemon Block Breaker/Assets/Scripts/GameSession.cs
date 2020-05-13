using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    //Configuration parameters
    [Range(0.1f,2f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 150;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool autoPlay = false;

    //State
    [SerializeField] int score = 0;

    //Singleton Pattern
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
            
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {    
        Time.timeScale = gameSpeed;
    }


    public void AddToScore(int maxHits)
    {
        score += pointsPerBlock / maxHits;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return autoPlay;
    }

    public bool IsLevel4()
    {
        bool isItLevel4 = (SceneManager.GetActiveScene().name == "Level 4") ? true :
                                                                              false;          
        return isItLevel4;
    }
}
