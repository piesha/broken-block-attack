﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{

    //config parameters
    [SerializeField] AudioClip breakSound=default;

    // cached reference
    Level level;
    


    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        DestroyBlock();
        
        
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        
    }

   
}
