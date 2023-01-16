using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 1f;
    [SerializeField] private AnimationCurve _shakeCurve;

    private void Awake()
    {
        ServiceLocator.Register(this);
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
