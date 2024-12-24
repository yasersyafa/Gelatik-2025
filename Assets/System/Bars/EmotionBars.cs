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
        bar.value = newValue;
    }
}
