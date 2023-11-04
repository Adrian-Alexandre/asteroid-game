using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float restartDelay = 5f;
    private bool gameEnded = false;
    private bool gameStarted = false;

    private PlayerController playerController;

    public TextMeshProUGUI scoreText;
    public float score;

    public GameObject asteroidPrefab;
    public GameObject text;
    
    public Transform[] spawnPoints;

    public float asteroidSpawnInterval = 3f;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        scoreText.text = "Score: " + score;
    }
    public void StartGame()
    {
        text.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Debug.Log("Game Started");
        playerController.SetCanInteract(true);

        InvokeRepeating("SpawnAsteroid", asteroidSpawnInterval, asteroidSpawnInterval);
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("Game Over");

            Invoke("RestartGame", restartDelay);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SpawnAsteroid()
    {
        float spawnDistance = 10f;
        float spawnAngle = Random.Range(0f, 360f);
        Vector2 spawnDirection = Quaternion.Euler(0f, 0f, spawnAngle) * Vector2.up;
        Vector2 spawnPosition = (Vector3)spawnDirection * spawnDistance;

        Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, -spawnDirection);

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, spawnRotation);
    }

}
