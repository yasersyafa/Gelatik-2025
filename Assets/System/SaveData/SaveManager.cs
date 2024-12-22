using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/playerSave.data";

    public static void SaveData(int currentDay, int currentMoney, int currentEmotion, int currentCalcium, int currentVitD, int currentFolicAcid, int currentIron, int currentProtein, List<string> badges)
    {
        BinaryFormatter formatter = new();
        FileStream stream = new(path, FileMode.Create);
        List<string> achievements = new();

        foreach(var achievement in badges)
        {
            achievements.Add(achievement);
        }

        PlayerData data = new(currentDay, currentMoney, currentEmotion, currentCalcium, currentVitD, currentFolicAcid, currentIron, currentProtein, achievements);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadGame()
    {
        try
        {
            if(File.Exists(path))
            {
                BinaryFormatter formatter = new();
                FileStream stream = new(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return data;
            }
            else
            {
                return new(1, 50000, 100, 100, 100, 100, 100, 100, new List<string>());
            } 
        }
        catch (System.Exception err)
        {
            Debug.LogError($"Error save data: {err.Message}");
            return null;
        }
        
    }
}
