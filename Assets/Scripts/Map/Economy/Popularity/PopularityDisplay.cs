using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopularityDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _popularityText;
    private void OnEnable()
    {
        PopularityController.OnPopularityUpdated += UpdatePopularityText;
    }

    private void OnDisable()
    {
        PopularityController.OnPopularityUpdated -= UpdatePopularityText;
    }

    private void UpdatePopularityText(int newPopularity)
    {
        _popularityText.text = $"{newPopularity}";
    }
}
