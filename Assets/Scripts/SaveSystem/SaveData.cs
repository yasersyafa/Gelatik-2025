using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int money, popularity;
    public string date, time;

    public List<string> workerNames;
    public List<string> transportationNames;
    public List<string> purchasedItemNames;

    public SaveData(GameManager game)
    {
        money = game.money;
        popularity = game.popularity;
        date = game.date;
        time = game.time;

        workerNames = new();
        transportationNames = new();
        purchasedItemNames = new();

        foreach(var worker in workerNames)
        {
            // workerNames.Add(worker.name);
        }

        foreach(var transportation in transportationNames)
        {
            // transportationNames.Add(transportation.name)
        }

        foreach(var purchasedItem in purchasedItemNames)
        {
            // purchasedItemNames.Add(purchasedItem.name)
        }
    }
}
