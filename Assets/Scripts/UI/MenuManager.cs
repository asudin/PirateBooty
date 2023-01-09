using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioClip))]
public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startPanel;
    [SerializeField] private AudioSource _buttonClick;
    [SerializeField] private AudioClip _effectClick;

    private void Start()
    {
        StartCoroutine(_startPanel.FadeIn());
    }

    private IEnumerator PlaySound(AudioSource sound, AudioClip soundEffect)
    {
        sound.PlayOneShot(soundEffect);
        yield return new WaitForSeconds(soundEffect.length); ;
    }

    public void StartGame()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(PlaySound(_buttonClick, _effectClick));
            SceneManager.LoadScene(1);
        }
    }
}
