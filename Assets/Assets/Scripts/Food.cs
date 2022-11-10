using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int points;
    private GameManager gameManager;
    public GameObject player;
    
    public virtual void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddPoints(points);
            Satisfy();
            Destroy(gameObject);
        }
        
    }
    public virtual void Satisfy() //ABSTRACTION
    {
        player.GetComponent<Player>().speed += 0;
    }
}
