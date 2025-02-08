using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/data.json";

    public static void SaveGame(GameManager game) // do not forget to assign GameManager param into the SaveGame function
    {
        SaveData data = new(game);
        string json =  JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static void LoadGame(GameManager game, DatabaseManager db)
    {
        if(!File.Exists(path))
        {
            return;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        
        game.money = data.money;
        game.popularity = data.popularity;
        game.date = data.date;
        game.time = data.time;

        // game.workers.Clear();
        game.transportations.Clear();
        game.purchasedItems.Clear();

        // add foreach for workers, transportation, purchasedItems
        foreach(string name in data.transportationNames)
        {
            Transportation transportation = db.GetTransportation(name);
            if(transportation != null) game.transportations.Add(transportation);
        }

        foreach(string name in data.purchasedItemNames)
        {
            Items item = db.GetItems(name);
            if(item != null) game.purchasedItems.Add(item);
        }
    }
}
