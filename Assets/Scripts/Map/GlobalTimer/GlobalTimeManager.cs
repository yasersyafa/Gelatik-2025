using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimeManager : MonoBehaviour
{
    public static event Action<int, int> OnTimeUpdated;

    private float _currentTimeInMinutes = 9 * 60; // 09.00 AM
    private float _timeSpeed = 0.8f; // 8 minutes in game / 1 seconds in real time
    private float _updateInterval = 5f; // update timer
    private float _nextUpdateTime;
    private static float endTime = 21 * 60;

    // Start is called before the first frame update
    void Start()
    {
        _nextUpdateTime = _currentTimeInMinutes + _updateInterval;
        NotifyTimeUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        _currentTimeInMinutes += _timeSpeed * Time.deltaTime;

        if(_currentTimeInMinutes >= _nextUpdateTime)
        {
            NotifyTimeUpdate();
            _nextUpdateTime += _updateInterval;
        }

        if(_currentTimeInMinutes >= endTime)
        {
            _currentTimeInMinutes = endTime;
        }
    }

    private void NotifyTimeUpdate()
    {
        int hours = (int)(_currentTimeInMinutes / 60);
        int minutes = (int)(_currentTimeInMinutes % 60);

        OnTimeUpdated?.Invoke(hours, minutes);
    }
}
