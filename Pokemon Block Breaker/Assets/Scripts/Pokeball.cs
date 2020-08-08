using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] Paddle paddle = default;
    [SerializeField] float ballVelocityX = 2f;
    [SerializeField] float ballVelocityY = 15f;
    [SerializeField] AudioClip[] ballSounds = default;
    [SerializeField] float ballRandomFactor = 0.2f;
    

    // State
    Vector2 paddleToBall;
    private bool hasStarted = false;
    private bool randomBounciness = false;

    //Cached references
    AudioSource myAudioSource;
    Rigidbody2D ballBody;


    // Start is called before the first frame update
    void Start()
    {
        // Ball attached to paddle
        paddleToBall = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        ballBody = GetComponent<Rigidbody2D>();

        if (FindObjectOfType<GameSession>().IsLevel4())
        {
            randomBounciness = true;
        }
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
            ballBody.velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Prevent boring loops
        Vector2 velocityTweak = new Vector2(x: Random.Range(0f, ballRandomFactor),
                                            y: Random.Range(0f, ballRandomFactor));
        
        if (hasStarted)
        {
            //Allows multiple ball sounds but Im only using 1
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            if (!randomBounciness)
            {
                ballBody.velocity += velocityTweak;
            }
            else
            {
                float verticalVelocity = (Random.Range(-1f, 1f) > 0f) ? ballRandomFactor : -ballRandomFactor;
                ballBody.velocity = new Vector2(x: Random.Range(-ballRandomFactor, ballRandomFactor),
                                                y: verticalVelocity);
            }

        }
    }
}
