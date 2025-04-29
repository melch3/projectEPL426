using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float gameDuration = 300f; // 5 minutes in seconds
    public Text timerText; // UI Text for the timer
    public Color normalColor = Color.white; // Default color
    public Color warningColor = Color.red; // Warning color

    private float timeRemaining;
    private bool isGameOver = false;

    void Start()
    {
        timeRemaining = gameDuration; // Initialize the timer
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isGameOver)
            return;

        // Countdown
        timeRemaining -= Time.deltaTime;

        // Update timer display
        UpdateTimerDisplay();

        // Change color when 2 minutes remain
        if (timeRemaining <= 120f)
        {
            timerText.color = warningColor;
        }

        // Check if time is up
        if (timeRemaining <= 0)
        {
            timeRemaining = 0; // Prevent negative values
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        // Convert time to minutes:seconds format
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("DeadScene");
    }
}
