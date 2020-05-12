using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Configuration Parameters
    int breakableBlocks;

    //Cached reference
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        breakableBlocks = GetTotalBlockNumber();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int GetTotalBlockNumber()
    {
        GameObject[] totalBreakableBlocks = GameObject.FindGameObjectsWithTag("Breakable");
        return totalBreakableBlocks.Length;
    }

    public void DecreaseTotalBlockNumber()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
