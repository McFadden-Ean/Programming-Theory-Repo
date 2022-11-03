using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int points = 10;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manger");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //gameManager.GetComponent<GameManager>().AddPoints(points);
            Destroy(gameObject);
        }
        
    }
}
