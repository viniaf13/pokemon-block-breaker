using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour
{
    //Load GameOver when the ball hits the collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadLastScene();
    }
}
