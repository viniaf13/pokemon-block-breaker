using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Cache reference
    Level level;
    //GameStatus gameStatus;
    
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.2f);
        level.DecreaseTotalBlockNumber();
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject);
    }
}
