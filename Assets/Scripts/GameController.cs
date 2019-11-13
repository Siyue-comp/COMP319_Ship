using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Variables that control spawning waves

    [Header("Wave Settings")]
    public GameObject hazard;   // What we are spawning
    public Vector2 spawnValue;  // Where are we spawning
    public int hazardCount;     // How many we are spawning

    [Header("Wave Time Settings")]
    public float startWait;     // How long until first wave
    public float spawnWait;     // How long between each hazard in a wave
    public float waveWait;      // How long between each wave

    [Header("UI Settings")]
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private bool gameOver;  bool restart;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = restart;
        UpdateScore();
        StartCoroutine(spawnWaves()); // Start my spawnWaves coroutine
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart our game (3methods)
                // Application.LoadLevel("Game"); old way do not use
                // The new way
                // SceneManager.LoadScene("Game");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    //Coroutine to spawn waves of hazards
    IEnumerator spawnWaves()
    {
        // Initial delay before my first wave
        yield return new WaitForSeconds(startWait); // Pause for "startWait" seconds

        while (true)
        {
            // Spawning Some hazards
            for(int i = 0; i < hazardCount; i++)
            {
                // Spawn a single hazard
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); //Wait for the next astroid
            }

            yield return new WaitForSeconds(waveWait); // Wait for the next Wave

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;
                
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue; // score = score + newScoreValue
        // Debug.Log("Score:" + score);
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);

    }
}
