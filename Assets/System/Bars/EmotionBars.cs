using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionBars : BarBase
{
    GameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        if(manager != null) manager.OnEmotionChanged += UpdateBar;
        bar.value = manager.emotion;
        barText.text = manager.emotion.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        if(manager != null) manager.OnEmotionChanged -= UpdateBar;
    }

    protected override void UpdateBar(int newValue)
    {
        int startValue = (int)bar.value;
        StartCoroutine(BarAnimation(startValue, newValue, 1));
        NgidamTrigger();
    }

    private bool NgidamTrigger()
    {
        int barValue = manager.emotion;
        if(barValue <= 50)
        {
            manager.isNgidam = true;
        }
        else if(barValue > 70)
        {
            manager.isNgidam = false;
        }
        else
        {
            int chance = Mathf.Clamp(100 - ((barValue - 50) * 2), 0, 100);
            manager.isNgidam = Random.Range(0, 100) < chance;
        }

        Debug.Log($"Istri Ngidam: {manager.isNgidam}");
        return manager.isNgidam;
    }
}
