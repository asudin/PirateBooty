using System.Collections;
using UnityEngine;

public static class CanvasGroupExtensions
{
    public static IEnumerator FadeIn(this CanvasGroup self, float time)
    {
        self.interactable = true;
        self.blocksRaycasts = true;

        while (self.alpha < 1)
        {
            self.alpha += Time.deltaTime * time;
            yield return null;
        }
    }

    public static IEnumerator FadeOut(this CanvasGroup self, float time)
    {
        self.interactable = false;
        self.blocksRaycasts = false;

        while (self.alpha > 0)
        {
            self.alpha -= Time.deltaTime * time;
            yield return null;
        }
    }

    public static void InstantClose(this CanvasGroup self)
    {
        self.interactable = false;
        self.blocksRaycasts = false;
        self.alpha = 0;
    }
}
