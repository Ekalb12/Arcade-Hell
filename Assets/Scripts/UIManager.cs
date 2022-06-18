using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text TimerText;
    public float timeRemaining;
    public GameObject [] Lives;
    public TextMeshProUGUI GameOverText;
    public Text IntroText;
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasePerSecond;
    public bool gameOver = false;

    // Start is called before the first frame update

    void Start ()
    {
        
        scoreAmount = 0f;
        pointIncreasePerSecond = 1f;
    }
    private void OnEnable()
    {
        GameEvents.OnGameTimerCountDown += OnGameTimerCountDownUpdated;
        GameEvents.OnDamageTaken += OnDamageTakenUpdated;
        GameEvents.OnGameOver += OnGameOverUpdated;
        
    }
    private void OnDisable()
    {
        GameEvents.OnGameTimerCountDown -= OnGameTimerCountDownUpdated;
        GameEvents.OnDamageTaken -= OnDamageTakenUpdated;
        GameEvents.OnGameOver -= OnGameOverUpdated;
        
    }
    
    private void OnGameTimerCountDownUpdated(int timeRemaining)
    {
        TimerText.text = "Timer: " + timeRemaining.ToString();
    }

    private void OnDamageTakenUpdated(int health)
    {
        if (health < 3)
        {
            Destroy(Lives[health].gameObject);
        }
        if (health == 0)
        {
            OnGameOverUpdated();
        }
    }
    private void OnGameOverUpdated()
    {
        
        
        GameOverText.enabled = true;
        GameOverText.text = "Game Over";
        GameEvents.OnGameLostFinal?.Invoke();
        gameOver = true;

    }

     
     void Update()
    {
       if (gameOver != true)
        {
        scoreText.text = (int)scoreAmount + "  Tickets";
        scoreAmount += pointIncreasePerSecond * Time.deltaTime;
        }
    }
}

