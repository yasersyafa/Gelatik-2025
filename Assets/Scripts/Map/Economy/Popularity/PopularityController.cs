using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopularityController : MonoBehaviour
{
    public static event Action<int> OnPopularityUpdated;
    private int _popularity;
    public int Popularity
    {
        get => _popularity;
        set
        {
            if(_popularity != value)
            {
                _popularity = Math.Max(0, value);
                OnPopularityUpdated?.Invoke(_popularity);
            }
        }
    }

    public void AddPopularity(int amount)
    {
        Popularity += amount;
    }

    public void ErasePopularity(int amount)
    {
        Popularity -= amount;
    }
}
