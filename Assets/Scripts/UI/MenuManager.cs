using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioClip))]
public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startPanel;
    [SerializeField] private AudioSource _buttonClick;

    private void Start()
    {
        StartCoroutine(_startPanel.FadeIn());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(PlaySound(_buttonClick));
        }
    }

    private IEnumerator PlaySound(AudioSource sound)
    {
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length);
        SceneManager.LoadScene(1);
    }
}
