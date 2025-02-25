using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class UiAnimations
{
    private const float MinAlpha = 0;

    public static IEnumerator AnimateFadeOut(this Image image, float duration, Action callback)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            image.color = Color.Lerp(new Color(image.color.r, image.color.g, image.color.b, image.color.a), new Color(image.color.r, image.color.g, image.color.b, MinAlpha), elapsedTime / duration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        callback?.Invoke();
    }
}
