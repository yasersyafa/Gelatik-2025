using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitaminDBar : BarBase
{
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        if(manager != null) manager.OnVitDChanged += UpdateBar;
        bar.value = manager.vitD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        if(manager != null) manager.OnVitDChanged -= UpdateBar;
    }

    protected override void UpdateBar(int barValue)
    {
        int startValue = (int)bar.value;
        StartCoroutine(BarAnimation(startValue, barValue, 1));
    }
}
