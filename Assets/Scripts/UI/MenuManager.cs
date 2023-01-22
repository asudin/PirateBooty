using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioClip))]
public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startPanel;
    [SerializeField] private CanvasGroup _shadowPanel;
    [SerializeField] private SoundManager _sounds;
    [SerializeField, Tooltip("Higher positive value equals faster fade in/out animation.")] private float _fadingTime;

    private SoundManager _soundManager;

    private void Start()
    {
        DontDestroyOnLoad(_sounds);
        StartCoroutine(_startPanel.FadeIn(_fadingTime));
        StartCoroutine(_shadowPanel.FadeOut(_fadingTime));
        _soundManager = ServiceLocator.Get<SoundManager>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(PlaySound(_soundManager.Play(SoundManager.Sounds.ButtonClick)));
        }
    }

    private IEnumerator PlaySound(AudioSource sound)
    {
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length);
        SceneManager.LoadScene(1);
    }
}
