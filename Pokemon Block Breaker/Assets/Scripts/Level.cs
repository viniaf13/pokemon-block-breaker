using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Parameters
    int breakableBlocks;

    //Cached reference
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        breakableBlocks = GetTotalBlockNumber();
        Debug.Log("total: " + breakableBlocks);
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int GetTotalBlockNumber()
    {
        GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("block");
        return allBlocks.Length;
    }

    public void DecreaseTotalBlockNumber()
    {
        breakableBlocks--;
        Debug.Log("total: " + breakableBlocks);
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
