using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    //Config params
    [SerializeField] Paddle paddle;
    [SerializeField] float ballVelocityX = 2f;
    [SerializeField] float ballVelocityY = 15f;
    

    // State
    Vector2 paddleToBall;
    public bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ball attached to paddle
        paddleToBall = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    // Ball sticks to the paddle
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddleToBall + paddlePos;
    }

    //Launch the ball from the paddle
    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
    }
}
