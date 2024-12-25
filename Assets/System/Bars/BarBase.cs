using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Slider bar;
    [SerializeField] protected TextMeshProUGUI barText;
    protected abstract void UpdateBar(int barValue);

    protected virtual IEnumerator BarAnimation(int start, int target, int duration)
    {
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            int currentValue = Mathf.RoundToInt(Mathf.Lerp(start, target, elapsedTime / duration));
            bar.value = currentValue;
            barText.text = currentValue.ToString() + "%";
            yield return null;
        }
        bar.value = target;
        barText.text = target.ToString() + "%";
    }
}
