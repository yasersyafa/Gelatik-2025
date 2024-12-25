using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolicAcidBar : BarBase
{
    GameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        if(manager != null) manager.OnFolicAcidChanged += UpdateBar;
        bar.value = manager.folicAcid;
        barText.text = manager.folicAcid.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        if(manager != null) manager.OnFolicAcidChanged -= UpdateBar;
    }

    protected override void UpdateBar(int barValue)
    { 
        int startValue = (int)bar.value;
        StartCoroutine(BarAnimation(startValue, barValue, 1));
    }
}
