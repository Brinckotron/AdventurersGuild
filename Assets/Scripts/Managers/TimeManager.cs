using System.Collections;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    // Time variables
    private int currentDay = 1;
    private int currentHour = 8;
    private int currentMinutes = 0;
    
    // Time progression settings
    private float timeScale = 1f; // 1 = normal, 0 = paused, 5 = fast forward
    private float realSecondsPerGameMinute = 1f; // Default: 1 real second = 1 game minute
    
    // References
    private GameManager gameManager;
    private Coroutine timeCoroutine;
    
    // Public properties
    public int CurrentDay => currentDay;
    public int CurrentHour => currentHour;
    public int CurrentMinutes => currentMinutes;
    public float TimeScale => timeScale;
    
    protected override void OnAwake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        StartTimeProgression();
    }
    
    private void StartTimeProgression()
    {
        // Stop any existing coroutine first
        if (timeCoroutine != null)
        {
            StopCoroutine(timeCoroutine);
        }
        
        // Start the time progression coroutine
        timeCoroutine = StartCoroutine(ProgressTime());
    }
    
    private IEnumerator ProgressTime()
    {
        while (true)
        {
            if (timeScale > 0)
            {
                // Wait for the appropriate amount of time based on the time scale
                yield return new WaitForSeconds(realSecondsPerGameMinute / timeScale);
                
                // Update the game time
                AdvanceOneMinute();
            }
            else
            {
                // If paused, just wait for the next frame
                yield return null;
            }
        }
    }
    
    private void AdvanceOneMinute()
    {
        // Increment minutes
        currentMinutes++;
        
        // Check if we need to advance to the next hour
        if (currentMinutes >= 60)
        {
            currentMinutes = 0;
            currentHour++;
            
            // Check if we need to advance to the next day
            if (currentHour >= 24)
            {
                currentHour = 0;
                currentDay++;
            }
            
            // You could add events here for hourly or daily triggers
            OnHourChanged();
        }
        
        // Update the UI
        UpdateTimeDisplay();
    }
    
    private void OnHourChanged()
    {
        // This can be used to trigger events at hour changes
        // For example, adventurers returning, quests completing, etc.
    }
    
    private void UpdateTimeDisplay()
    {
            gameManager.UpdateTime();
    }
    
    // Public methods for controlling time
    public void PauseTime()
    {
        timeScale = 0f;
        gameManager.UpdateTimeScale();
    }
    
    public void ResumeTime()
    {
        timeScale = 1f;
        gameManager.UpdateTimeScale();
    }
    
    public void FastForwardTime()
    {
        timeScale = 10f;
        gameManager.UpdateTimeScale();
    }
    
    // Method to set a specific time (for debugging or events)
    public void SetTime(int day, int hour, int minute)
    {
        currentDay = day;
        currentHour = hour;
        currentMinutes = minute;
        UpdateTimeDisplay();
    }
}