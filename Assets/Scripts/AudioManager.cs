using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    public static AudioManager Instance;
    public static bool isPause = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound S in Sounds)
        {
            S.Source = gameObject.AddComponent<AudioSource>();
            S.Source.clip = S.Clip;
            S.Source.volume = S.Volume;
            S.Source.pitch = S.Pitch;
            S.Source.loop = S.Loop;
        }
    }

    void Start()
    {
        Play("Theme");
        
    }
    #region Standard Method
    public void Play (string Name)
    {
        Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + Name + "not found!");
            return;
        }
        S.Source.Play();
    }
    public void Stop(string Name)
    {
        Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + Name + "not found!");
            return;
        }
        S.Source.Stop();
    }
    public void Pause(string Name)
    {
        Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + Name + "not found!");
            return;
        }
        S.Source.Pause();
    }
    public void Volume(string Name, Slider SliderVolume)
    {
        Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (S == null)
        {
            Debug.LogWarning("Sound: " + Name + "not found!");
            return;
        }
        S.Source.volume = SliderVolume.value;
        PlayerPrefs.SetFloat("Volume", SliderVolume.value);
    }
    #endregion
    #region Advance Method
    public void EffectivePause(string Name)
    {
        if (isPause == true)
        {
            Pause(Name);
            isPause = false;
        }
        else if (isPause == false)
        {
            Instance.Play(Name);
            isPause = true;
        }
    }
    #endregion
}



//Per usarlo usare AudioManager.Instance.Play("NomeCanzone") è più veloce