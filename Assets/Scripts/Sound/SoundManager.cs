using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<Sound> _sounds;

    private AudioSource[] _audioSources;

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
        ServiceLocator.Register(this);
    }

    public AudioSource Play(Sounds sound, bool loop = false)
    {
        var availableSource = _audioSources.FirstOrDefault(source => !source.isPlaying);

        if (availableSource == null) 
            return null;

        availableSource.clip = _sounds.Find(s => s.Name == sound).Clip;
        availableSource.loop = loop;
        availableSource.Play();
        return availableSource;
    }

    public AudioSource PlayInLoop(Sounds sound)
    {
        return Play(sound, true);
    }

    [Serializable]
    public class Sound
    {
        public string Label;
        public Sounds Name;
        public AudioClip Clip;
    }

    public enum Sounds
    {
        Click,
        Jump,
        PlayerDeath,
        EnemyDeath,
        Explosion,
        Pellets,
        Bullet,
        CratePicked,
        ChestReached,
        GameOver
    }
}
