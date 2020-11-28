using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider SliderVolume;
    private void Start()
    {
        SliderVolume.value = PlayerPrefs.GetFloat("Volume");
    }
    private void Update()
    {
        ChangeVolume();
    }
    public void ChangeVolume()
    {
        AudioManager.Instance.Volume("Theme", SliderVolume);
    }
}
