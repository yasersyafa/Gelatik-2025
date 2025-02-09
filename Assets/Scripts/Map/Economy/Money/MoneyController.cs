using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static event Action<int> OnMoneyUpdated;
    private int money;

    public int Money
    {
        get => money;

        set
        {
            if(money != value) {
                money = Math.Max(0, value);
                OnMoneyUpdated?.Invoke(money);
            }
            
        }
    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void SpendMoney(int amount)
    {
        Money -= amount;
    }
}
