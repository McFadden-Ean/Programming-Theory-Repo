using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The number of points is " + currentScore);
    }

    public int AddPoints(int points)
    {
        currentScore += points;
        return currentScore;
    }
}
