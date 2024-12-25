using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int day;
    public int money;
    [HideInInspector]
    public int emotion, calcium, vitD, folicAcid, iron, protein;

    public bool isNgidam;

    // observer events 
    public event Action<int> OnCalciumChanged;
    public event Action<int> OnEmotionChanged;
    public event Action<int> OnVitDChanged;
    public event Action<int> OnFolicAcidChanged;
    public event Action<int> OnIronChanged;
    public event Action<int> OnProteinChanged;
    
    public List<string> badges = new();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    void Update()
    {
        // checking the unity events
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DecreaseStats();
        }
    }

    public void Eat()
    {
        IncreaseStats();
        SaveManager.SaveData(day, money, emotion, calcium, vitD, folicAcid, iron, protein, badges);
    }

    public void NextDay()
    {
        DecreaseStats();
    }

    public void LoadData()
    {
        PlayerData data = SaveManager.LoadGame();

        if(data != null)
        {
            day = data.Day;
            money = data.Money;
            emotion = data.Emotion;
            calcium = data.Calcium;
            vitD = data.VitD;
            folicAcid = data.FolicAcid;
            iron = data.Iron;
            protein = data.Protein;

            // list achievements
            badges = data.Achievements;
        }
        else
        {
            day = 1;
            money = 50_000;
            emotion = 100;
            calcium = 100;
            vitD = 100;
            folicAcid = 100;
            iron = 100;
            protein = 100;
        }
    }

    public void DecreaseStats()
    {
        int RANDOM_EMOTION = UnityEngine.Random.Range(-31, -19);
        int RANDOM_CALCIUM = UnityEngine.Random.Range(-21, -11);
        int RANDOM_VITD = UnityEngine.Random.Range(-21, -4);
        int RANDOM_FOLICACID = UnityEngine.Random.Range(-21, -14);
        int RANDOM_IRON = UnityEngine.Random.Range(-21, -6);
        int RANDOM_PROTEIN = UnityEngine.Random.Range(-21, -9);

        // set random decreaseValue
        SetEmotion(RANDOM_EMOTION);
        SetCalcium(RANDOM_CALCIUM);
        SetVitaminD(RANDOM_VITD);
        SetFolicAcid(RANDOM_FOLICACID);
        SetIron(RANDOM_IRON);
        SetProtein(RANDOM_PROTEIN);
    }

    public void IncreaseStats()
    {

    }

#region SetterStats
    private void SetEmotion(int decreaseValue)
    {
        emotion += decreaseValue;
        if(emotion >= 100) emotion = 100;
        if(emotion <= 0) emotion = 0;
        OnEmotionChanged?.Invoke(emotion);
    }
    private void SetCalcium(int decreaseValue)
    {
        calcium += decreaseValue;
        if(calcium >= 100) calcium = 100;
        if(calcium <= 0) calcium = 0;
        OnCalciumChanged?.Invoke(calcium);
    }

    private void SetVitaminD(int decreaseValue)
    {
        vitD += decreaseValue;
        if(vitD >= 100) vitD = 100;
        if(vitD <= 0) vitD = 0;
        OnVitDChanged?.Invoke(vitD);
    }

    private void SetFolicAcid(int decreaseValue)
    {
        folicAcid += decreaseValue;
        if(folicAcid >= 100) folicAcid = 100;
        if(folicAcid <= 0) folicAcid = 0;
        OnFolicAcidChanged?.Invoke(folicAcid);
    }

    private void SetIron(int decreaseValue)
    {
        iron += decreaseValue;
        if(iron >= 100) iron = 100;
        if(iron <= 0) iron = 0;
        OnIronChanged?.Invoke(iron);
    }

    private void SetProtein(int decreaseValue)
    {
        protein += decreaseValue;
        if(protein >= 100) protein = 100;
        if(protein <= 0) protein = 0;
        OnProteinChanged?.Invoke(protein);
    }
#endregion
}
