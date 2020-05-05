using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minPaddle = 1f;
    [SerializeField] float maxPaddle = 15f;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);

        //Mouse x position in units
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //Declare a variable that stores xy
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        //Locks the paddle inside the screen
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minPaddle, maxPaddle);

        //Move the paddle
        transform.position = paddlePos;
    }
}
