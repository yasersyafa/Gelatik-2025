using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Day { get; set; }
    public int Money { get; set; }

    // Bar stats
    public int Emotion { get; set; }
    public int VitD { get; set; }
    public int Calcium { get; set; }
    public int FolicAcid { get; set; }
    public int Iron { get; set; }
    public int Protein { get; set; }
    public List<string> Achievements { get; set; }

    // Constructor
    public PlayerData(int currentDay, int currentMoney, int currentEmotion, int currentCalcium, int currentVitD, int currentFolicAcid, int currentIron, int currentProtein, List<string> badges)
    {
        Day = currentDay;
        Money = currentMoney;
        Emotion = currentEmotion;
        Calcium = currentCalcium;
        VitD = currentVitD;
        FolicAcid = currentFolicAcid;
        Iron = currentIron;
        Protein = currentProtein;
        Achievements = badges ?? new List<string>();
    }
}
