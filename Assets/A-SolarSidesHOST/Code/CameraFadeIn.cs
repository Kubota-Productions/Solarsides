using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraFadeIn : MonoBehaviour
{
    public CanvasGroup blackScreenCanvasGroup;  // CanvasGroup component attached to the black screen
    public float fadeDuration = 2f;  // Duration of the fade-in effect

    void Start()
    {
        if (blackScreenCanvasGroup != null)
        {
            // Ensure the screen starts fully black with full opacity
            blackScreenCanvasGroup.alpha = 1f;
            blackScreenCanvasGroup.blocksRaycasts = true;
            // Start the fade-in effect
            StartCoroutine(FadeIn());
        }
        else
        {
            Debug.LogError("Black Screen CanvasGroup is not assigned.");
        }
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreenCanvasGroup.alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            yield return null;
        }

        // Ensure the screen is fully transparent at the end of the fade-in
        blackScreenCanvasGroup.alpha = 0f;
        blackScreenCanvasGroup.blocksRaycasts = false;  // Make sure it doesn't block UI interactions
    }
}