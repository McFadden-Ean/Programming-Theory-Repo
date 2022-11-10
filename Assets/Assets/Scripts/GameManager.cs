using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartButton;
    [SerializeField] Button homeButton;
    [SerializeField] TextMeshProUGUI timer;

    [SerializeField] List<GameObject> foodPrefabs;

    public int currentScore;
    public bool isGameActive;
    private float zBound = 4.0f;
    private float xBound = 9.0f;
    private float maxTime = 1800.0f;
    private float timeDecrease = 60.0f;
    [SerializeField] float spawnRate;
    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnFood());
        AddPoints(currentScore);
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    public int AddPoints(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore;
        return currentScore;
    }
    IEnumerator SpawnFood() { 
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, foodPrefabs.Count);
            if (isGameActive)
            {
                Instantiate(foodPrefabs[index], SpawnPosition(), foodPrefabs[index].transform.rotation);
            }
        }
    
    }
    Vector3 SpawnPosition()
    {
        float xPos = Random.Range(-xBound, xBound);
        float zPos = Random.Range(-zBound, zBound);

        Vector3 spawn = new Vector3(xPos, 0, zPos);
        return spawn;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        homeButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        music.gameObject.SetActive(false);
        isGameActive = false;
        HighScoreUpdate();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
    void Timer()
    {
        if (maxTime > 0)
        {
            maxTime -= timeDecrease * Time.deltaTime;
            timer.text = "Timer: " + Mathf.Round(maxTime / 60);
        }
        if (maxTime <= 0)
        {
            GameOver();
        }
    }
    void HighScoreUpdate()
    {
        if (currentScore > MainManager.Instance.highScore)
        {
            MainManager.Instance.highScore = currentScore;
            MainManager.Instance.highName = MainManager.Instance.sessionName;
            MainManager.Instance.SaveHighScore(MainManager.Instance.highScore, MainManager.Instance.highName);
        }
    }
}
