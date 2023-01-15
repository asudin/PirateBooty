using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioClip))]
public class MenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _startPanel;
    [SerializeField] private SoundManager _sounds;
    [SerializeField, Tooltip("Higher positive value equals faster fade in/out animation.")] private float _time;

    private SoundManager _soundManager;

    private void Start()
    {
        DontDestroyOnLoad(_sounds);
        StartCoroutine(_startPanel.FadeIn(_time));
        _soundManager = ServiceLocator.Get<SoundManager>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(PlaySound(_soundManager.Play(SoundManager.Sounds.Click)));
        }
    }

    private IEnumerator PlaySound(AudioSource sound)
    {
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length);
        SceneManager.LoadScene(1);
    }
}
