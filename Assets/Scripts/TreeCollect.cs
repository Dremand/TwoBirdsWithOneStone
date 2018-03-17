﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollect : MonoBehaviour {

    private GameObject[] pipeHolders;
    private float distance = 5f;
    private float lastPipesX;
    private float pipeMin = -1.5f;
    private float pipeMax = 2.4f;
   // public GameObject bird;

    private void Awake()
    {
        pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

        for (int i = 0; i < pipeHolders.Length; i++)
        {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
        }

        lastPipesX = pipeHolders[0].transform.position.x;

        for (int i = 1; i < pipeHolders.Length; i++)
        {
            if (lastPipesX < pipeHolders[i].transform.position.x)
            {
                lastPipesX = pipeHolders[i].transform.position.x;
            }
        }
       
      //  bird.gameObject.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "PipeHolder")
        {

            Vector3 temp = target.transform.position;

            temp.x = lastPipesX + distance;
            temp.y = Random.Range(pipeMin, pipeMax);

            target.transform.position = temp;

            lastPipesX = temp.x;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            gameObject.SetActive(true);
        }
    }
}
