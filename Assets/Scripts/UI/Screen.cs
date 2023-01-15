using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;

    public abstract void Open();

    public abstract void Close();
}
