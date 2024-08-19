using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] musicSounds, sfxSounds;
    [SerializeField] private AudioSource musicSource, sfxSource;


    public static AudioManager Instance;

    ///Unity
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }
    ///Playing And Stopping
    //Play
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Could not find sound " + name);
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Could not find sound " + name);
            return;
        }

        sfxSource.clip = s.clip;
        sfxSource.Play();
    }


    //Stop
    public void StopMusic() => musicSource.Stop();
    public void StopSFX() => sfxSource.Stop();

    ///Audio Settings
    //Mute
    public void ToggleMusic() => musicSource.mute = !musicSource.mute;
    public void ToggleSFX() => sfxSource.mute = !sfxSource.mute;

    //Volume
    public void MusicVolume(float volume) => musicSource.volume = volume;
    public void SFXVolume(float volume) => sfxSource.volume = volume;

}
