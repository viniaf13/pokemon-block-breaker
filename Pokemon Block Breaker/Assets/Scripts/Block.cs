using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 1;
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    Level level;

    //State
    int timesHit = 0;

    
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            handleHit();
        }
    }

    private void handleHit()
    {
        timesHit++;
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.2f);
        if (timesHit == maxHits)
        {
            DestroyBlock();
        }
        else
        {
            FindObjectOfType<GameSession>().AddToScore(maxHits);
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        level.DecreaseTotalBlockNumber();
        FindObjectOfType<GameSession>().AddToScore(maxHits);
        TriggerDestroyEffects();
        Destroy(gameObject);
    }

    //Activate visual effects
    private void TriggerDestroyEffects()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
