using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 1f;
    [SerializeField] private AnimationCurve _shakeCurve;

    public event Action Registered;

    private void Awake()
    {
        if (ServiceLocator.IsObjectRegistered == false)
        {
            ServiceLocator.Register(this);
            DontDestroyOnLoad(this);
            Registered?.Invoke();
        }
    }

    private IEnumerator Shaking(float shakeDuration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < _shakeDuration)
        {
            float shakeStrength = _shakeCurve.Evaluate(elapsedTime / _shakeDuration);
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere * shakeStrength;
            yield return null;
        }

        transform.position = startPosition;
    }

    public void Shake(float shakeDuration)
    {
        StartCoroutine(Shaking(shakeDuration));
    }
}
