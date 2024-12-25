using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronBar : BarBase
{
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        if(manager != null) manager.OnIronChanged += UpdateBar;
        bar.value = manager.iron;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        if(manager != null) manager.OnIronChanged -= UpdateBar;
    }

    protected override void UpdateBar(int barValue)
    {
        int startValue = (int)bar.value;
        StartCoroutine(BarAnimation(startValue, barValue, 1));
    }
}
