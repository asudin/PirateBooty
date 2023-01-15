using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : Screen
{
    public override void Close()
    {
        StartCoroutine(CanvasGroup.FadeOut());
    }

    public override void Open()
    {
        StartCoroutine(CanvasGroup.FadeIn());
    }
}
