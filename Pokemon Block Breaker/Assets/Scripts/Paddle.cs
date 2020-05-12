using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPaddle = 1f;
    [SerializeField] float maxPaddle = 15f;

    //Cached references
    GameSession gameSession;
    Pokeball pokeball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        pokeball = FindObjectOfType<Pokeball>();
    }

    void Update()
    { 
        //Declare a variable that stores xy
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        //Locks the paddle inside the screen
        paddlePos.x = Mathf.Clamp(GetXPos(), minPaddle, maxPaddle);

        //Move the paddle
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        //Choose auto or mouse
        if (gameSession.IsAutoplayEnabled())
        {
            return pokeball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
