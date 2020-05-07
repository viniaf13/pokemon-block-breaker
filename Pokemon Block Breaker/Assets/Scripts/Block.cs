using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //Cache reference
    Level level; 
    
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.2f);
        level.DecreaseTotalBlockNumber();
        Destroy(gameObject);
    }


}
