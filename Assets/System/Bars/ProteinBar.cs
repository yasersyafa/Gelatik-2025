using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProteinBar : BarBase
{
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        if(manager != null) manager.OnProteinChanged += UpdateBar;
        bar.value = manager.protein;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        if(manager != null) manager.OnProteinChanged -= UpdateBar;
    }

    protected override void UpdateBar(int barValue)
    {
        bar.value = barValue;
    }
}
