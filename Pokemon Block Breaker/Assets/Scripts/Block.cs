using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    //Cache reference
    Level level;
    //GameStatus gameStatus;
    
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        level.DecreaseTotalBlockNumber();
        FindObjectOfType<GameSession>().AddToScore();
        TriggerDestroyEffects();
        Destroy(gameObject);
    }

    //Activate visual and sound effects
    private void TriggerDestroyEffects()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.2f);
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
