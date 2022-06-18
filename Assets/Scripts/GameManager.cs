using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List <Enemies> enemies;

    public int score;
    public float moveSpeed = 6.0f;
    public float sideOutOfBounds = 18.0f;
    public float TopOutOfBounds = 5f;
    public int playerScore;
    public List<SpawnDirection> spawnpointAll;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // start the couroutines to spawn enemies and spawn targets and timer
       
        StartCoroutine(SpawnTarget1());
        StartCoroutine(Timmer());

    }
    

    // Update is called once per frame
    // destroy the enemies when they get out of the screen
    void Update()
    {
        if (transform.position.x > sideOutOfBounds)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > TopOutOfBounds)
        {
            Destroy(gameObject);
        }
    }
   
    // Spawn enemies in different spawn points 
    IEnumerator SpawnTarget1()
    {
        while (true)
        {
            if (gameOver != true)
            {
                yield return new WaitForSeconds(0.5f);
                int RandompositionIndex = Random.Range(0, spawnpointAll.Count);
                int RandomEnemieIndex = Random.Range(0, enemies.Count);

                SpawnDirection Randomposition = spawnpointAll[RandompositionIndex];

                Enemies newEnemy = Instantiate(enemies[RandomEnemieIndex], Randomposition.transform.position, Quaternion.identity);
                newEnemy.moveDirection = Randomposition.startDirection;

            }
            else if (gameOver == true)
            {
                Debug.Log("Stop");
            }

            //Debug.Log($"SpawnTarget1: {newEnemy.name} {newEnemy.moveDirection}");
        }
    }
    // Timmer and countdown from 120 secs to 0 
    public IEnumerator Timmer()
    {
        if (gameOver != true)
        {
            int timeRemaining = 30;
            while (timeRemaining > 0) 
            {
                yield return new WaitForSeconds(1f);
                timeRemaining--;
                GameEvents.OnGameTimerCountDown?.Invoke(timeRemaining);

            }
             if (timeRemaining == 0)
            {
                GameEvents.OnGameLostFinal?.Invoke();
                GameEvents.OnGameOver?.Invoke();
            }
     
            
        }
        else if (gameOver == true)
            {
                Debug.Log("StopTimer");
            }
    }

    private void OnEnable()
    {
        GameEvents.OnGameLostFinal += OnGameLostFinalUpdated;
    }

    private void OnDisable()
    {
        GameEvents.OnGameLostFinal -= OnGameLostFinalUpdated;
    }
     private void OnGameLostFinalUpdated()
    {
        gameOver = true;
            Debug.Log("Stop Coroutines");
        if (gameOver == true)
        {
            StopAllCoroutines();
        }
    }

    public void RestartGame()
    {
        // restarts game w/ the reset button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        // starts game w/ the start button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
