using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float totalTime = 70f;  // Set your desired countdown time
    public  float currentTime;

    public  TextMeshProUGUI timeText; 

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            
            //Debug.Log("Time's up!");
            //gameObject.SetActive(false);
            //timeText.gameObject.SetActive(false);
            return; 
        }
    }

    void UpdateTimerText()
    {
        // Format the time as minutes:seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the UI Text component
        timeText.text = timeString;
    }
}
