using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private void OnEnable()
    {
        GlobalTimeManager.OnTimeUpdated += UpdateTimerText;
    }

    private void OnDisable()
    {
        GlobalTimeManager.OnTimeUpdated -= UpdateTimerText;
    }

    private void UpdateTimerText(int hours, int minutes)
    {
        string period = (hours >= 12) ? "PM" : "AM";
        int displayHour = (hours > 12) ? hours - 12 : hours;
        if (displayHour == 0) displayHour = 12;

        _timerText.text = $"{displayHour:D2}:{minutes:D2} {period}";
    }
}
