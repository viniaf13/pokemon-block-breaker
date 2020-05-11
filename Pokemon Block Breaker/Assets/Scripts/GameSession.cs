using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    //Config params
    [Range(0.1f,2f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 100;
    [SerializeField] TextMeshProUGUI scoreText;

    //State variables
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


    public void AddToScore()
    {
        score += pointsPerBlock;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
