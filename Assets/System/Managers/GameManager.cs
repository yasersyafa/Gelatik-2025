using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int day;
    public int money;
    public int emotion, calcium, vitD, folicAcid, iron, protein;
    
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
        SaveManager.LoadGame();
    }

    public void NextDay()
    {
        SaveManager.SaveData(day, money, emotion, calcium, vitD, folicAcid, iron, protein, badges);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
