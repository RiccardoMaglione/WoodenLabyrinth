using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MaglioneFramework
{
    namespace WoodenLabyrinth
    {
        public class GameManager : MonoBehaviour
        {
            #region Variables
            public GameObject MenuPanel;
            public GameObject OptionPanel;
        
            public Slider SliderSensibility;
            public Text SensibilityTextValue;
        
            public Slider SliderVolume;
            public Text VolumeTextValue;
        
            public Toggle ToggleShader;
            public Text ShaderTextValue;
            #endregion
        
            private void Start()
            {
                #region Set Sensibility
                //Verifico a inizio gioco il valore della sensibility e lo setto
                SliderSensibility.value = PlayerPrefs.GetInt("Sensibility");                    
                SensibilityTextValue.text = ((int)SliderSensibility.value).ToString();
                #endregion
        
                #region Set Volume
                //Verifico a inizio gioco il valore del volume e lo setto
                SliderVolume.value = PlayerPrefs.GetFloat("Volume");
                AudioManager.Instance.Volume("Theme", SliderVolume);
                VolumeTextValue.text = (SliderVolume.value * 100).ToString("0");
                #endregion
        
                #region Set XRay
                //Verifico se a inizio gioco l'xray precedemente era attiva o no
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
                #endregion
            }
        
            #region Method
            /// <summary>
            /// Metodo per andare alla scena di gioco
            /// </summary>
            public void GoToPlay()
            {
                SceneManager.LoadScene("SampleScene");
            }
        
            /// <summary>
            /// Metodo per andare alle opzioni dal menu
            /// </summary>
            public void GoToOption()
            {
                MenuPanel.SetActive(false);
                OptionPanel.SetActive(true);
            }
        
            /// <summary>
            /// Metodo per andare al menu dalle opzioni
            /// </summary>
            public void GoToBack()
            {
                MenuPanel.SetActive(true);
                OptionPanel.SetActive(false);
            }
        
            /// <summary>
            /// Metodo per cambiare la sensibilità dell'accelerometro
            /// </summary>
            public void ValueSensibility()
            {
                PlayerPrefs.SetInt("Sensibility", (int)SliderSensibility.value);
                SensibilityTextValue.text = ((int)SliderSensibility.value).ToString();
            }
        
            /// <summary>
            /// Metodo per cambiare il volume
            /// </summary>
            public void ChangeVolume()
            {
                AudioManager.Instance.Volume("Theme", SliderVolume);
                VolumeTextValue.text = (SliderVolume.value * 100).ToString("0");
            }
        
            /// <summary>
            /// Metodo per attivare e disattivare l'xray
            /// </summary>
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
            #endregion
        }
    }
}