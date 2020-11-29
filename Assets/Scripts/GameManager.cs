using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject OptionPanel;

    public Slider SliderSensibility;
    public Text SensibilityTextValue;

    public Slider SliderVolume;
    public Text VolumeTextValue;

    public Toggle ToggleShader;
    public Text ShaderTextValue;

    private void Start()
    {
        SliderSensibility.value = PlayerPrefs.GetInt("Sensibility");
        SensibilityTextValue.text = ((int)SliderSensibility.value).ToString();

        SliderVolume.value = PlayerPrefs.GetFloat("Volume");
        AudioManager.Instance.Volume("Theme", SliderVolume);
        VolumeTextValue.text = (SliderVolume.value * 100).ToString("0");

        if (PlayerPrefs.GetInt("ActiveShaderXray") == 1)
        {
            ToggleShader.isOn = true;
            ShaderTextValue.text = "On";
        }
        else if(PlayerPrefs.GetInt("ActiveShaderXray") == 0)
        {
            ToggleShader.isOn = false;
            ShaderTextValue.text = "Off";
        }
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToOption()
    {
        MenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void GoToBack()
    {
        MenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }
    public void ValueSensibility()
    {
        PlayerPrefs.SetInt("Sensibility", (int)SliderSensibility.value);
        SensibilityTextValue.text = ((int)SliderSensibility.value).ToString();
    }

    public void ChangeVolume()
    {
        AudioManager.Instance.Volume("Theme", SliderVolume);
        VolumeTextValue.text = (SliderVolume.value * 100).ToString("0");
    }

    public void XRay()
    {
        if(ToggleShader.isOn == true)
        {
            PlayerPrefs.SetInt("ActiveShaderXray", 1);
            ShaderTextValue.text = "On";
        }
        else
        {
            PlayerPrefs.SetInt("ActiveShaderXray", 0);
            ShaderTextValue.text = "Off";
        }
    }
}
