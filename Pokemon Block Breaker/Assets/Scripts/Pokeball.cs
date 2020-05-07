using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    //Config params
    [SerializeField] Paddle paddle;
    [SerializeField] float ballVelocityX = 2f;
    [SerializeField] float ballVelocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    

    // State
    Vector2 paddleToBall;
    private bool hasStarted = false;

    //Cached componente references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Ball attached to paddle
        paddleToBall = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            //Allows multiple ball sounds but Im only using 1
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
