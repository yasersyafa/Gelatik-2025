using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money, popularity;
    public string date, time;

    // public List<Worker> workers;
    public List<Transportation> transportations;
    public List<Items> purchasedItems;

    public DatabaseManager database;
    
    public void SaveGame()
    {
        SaveManager.SaveGame(this);
    }

    public void LoadGame()
    {
        SaveManager.LoadGame(this, database);
    }
}
