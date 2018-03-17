using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDeath : MonoBehaviour {
    public GameObject bird;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bird.gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (collision.gameObject.tag == "TreeCollector")
        {
            bird.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
