using UnityEngine;
using System.Collections;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float transitionDuration = 2.0f; // Waktu transisi warna dalam detik

    private Color morningColor = new Color32(209, 248, 239, 255); // #D1F8EF (Pagi)
    private Color eveningColor = new Color32(255, 217, 95, 255);  // #FFD95F (Sore)
    private Color nightColor = new Color32(73, 61, 158, 255);     // #493D9E (Malam)

    private void OnEnable()
    {
        GlobalTimeManager.OnTimeUpdated += UpdateBackgroundColor; // Subscribe event
    }

    private void OnDisable()
    {
        GlobalTimeManager.OnTimeUpdated -= UpdateBackgroundColor; // Unsubscribe event
    }

    private void UpdateBackgroundColor(int hours, int minutes)
    {
        Color targetColor;

        if (hours >= 17 && hours < 19) // 5:00 PM - 6:59 PM (Sore)
        {
            targetColor = eveningColor;
        }
        else if (hours >= 19) // 7:00 PM - 9:00 PM (Malam)
        {
            targetColor = nightColor;
        }
        else // Pagi atau sebelum sore
        {
            targetColor = morningColor;
        }

        StopAllCoroutines(); // Hentikan transisi sebelumnya agar tidak bertumpuk
        StartCoroutine(SmoothTransition(targetColor));
    }

    private IEnumerator SmoothTransition(Color targetColor)
    {
        Color startColor = mainCamera.backgroundColor;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            mainCamera.backgroundColor = Color.Lerp(startColor, targetColor, t);
            yield return null; // Tunggu frame berikutnya
        }

        mainCamera.backgroundColor = targetColor; // Pastikan warna akhir benar
    }
}
