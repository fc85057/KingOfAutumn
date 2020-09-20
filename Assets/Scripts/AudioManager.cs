using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private string currentSong;
    private bool musicOn;
    private bool sfxOn;
    private Dictionary<string, AudioSource> sounds;

    public static AudioManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);

        musicOn = true;
        sfxOn = true;

        LoadSounds();
    }

    private void LoadSounds()
    {
        sounds = new Dictionary<string, AudioSource>();
        AudioSource[] audioSources = GetComponents<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            sounds.Add(audioSource.name, audioSource);
        }
    }

    public void SetMusic(bool on)
    {
        musicOn = on;

        if (on)
            sounds[currentSong].UnPause();
        else
            sounds[currentSong].Pause();
    }

    public void SetSfx(bool on)
    {
        sfxOn = on;
    }

    public void PlaySound(string sound)
    {
        if (!sfxOn)
            return;

        sounds[sound].Play();
    }

    public void PlayMusic(string sound)
    {
        if (!musicOn)
            return;

        sounds[sound].Play();
        currentSong = sound;
    }

    public void StopMusic(string sound)
    {
        if (!musicOn)
            return;

        sounds[sound].Pause();
    }

}
