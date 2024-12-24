using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BarBase : MonoBehaviour
{
    [SerializeField] protected Slider bar;
    protected abstract void UpdateBar(int barValue);

    protected virtual IEnumerator BarAnimation(int start, int target, int duration)
    {
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            int currentValue = Mathf.RoundToInt(Mathf.Lerp(start, target, elapsedTime / duration));
            UpdateBar(currentValue);
            yield return null;
        }
        UpdateBar(target);
    }
}
