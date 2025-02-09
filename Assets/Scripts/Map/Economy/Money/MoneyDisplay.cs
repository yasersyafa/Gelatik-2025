using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    private void OnEnable()
    {
        MoneyController.OnMoneyUpdated += UpdateMoneyText;
    }

    private void OnDisable()
    {
        MoneyController.OnMoneyUpdated -= UpdateMoneyText;
    }

    private void UpdateMoneyText(int newMoney)
    {
        _moneyText.text = $"{FormatMoneyText(newMoney)}";
    }

    private string FormatMoneyText(int amount)
    {
        if(amount >= 1_000_000)
        {
            float value = amount / 1_000_000f;
            return value % 1 == 0 ? $"{(int)value}JT" : $"{value:0.0}JT";
        } 
        if(amount >= 1_000)
        {
            float value = amount / 1_000f;
            return value % 1 == 0 ? $"{(int)value}RB" : $"{value:0.0}RB";
        }
        
        return amount.ToString();
    }
}
