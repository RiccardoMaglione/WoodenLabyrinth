using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MaglioneFramework
{
    namespace WoodenLabyrinth
    {
        public class LevelManager : MonoBehaviour
        {
            #region Variables
            public GameObject Ball;                 //Inizializzo la palla
            public Material NormalMaterial;         //Inizializzo il materiale normale (Shader Metallic)
            public Material ShaderXRayMaterial;     //Inizializzo il materiale per l'xrau (Shader WallShader)
            Material[] matArrayStandard;            //Inizializzo un array per contenere i materiali
            public Text CheckpointText;             //Inizializzo il testo per il valore di quante volte completi il percordo
            int CountWin;                           //Inizializzo il conteggio delle vittorie
            #endregion

            private void Update()
            {
                #region Set Xray Material
                //If statement per il cambio di materiale in base al valore dell'xray
                if (PlayerPrefs.GetInt("ActiveShaderXray") == 1)
                {
                    matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
                    matArrayStandard[1] = ShaderXRayMaterial;
                    Ball.GetComponent<MeshRenderer>().materials = matArrayStandard;
                }
                if (PlayerPrefs.GetInt("ActiveShaderXray") == 0)
                {
                    matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
                    matArrayStandard[1] = NormalMaterial;
                    Ball.GetComponent<MeshRenderer>().materials = matArrayStandard;
                }
                #endregion

                DetectWin();
            }

            #region Function and Method
            #region Scene Management
            /// <summary>
            /// Metodo per tornare alla scena del menu
            /// </summary>
            public void BackToMenu()
            {
                SceneManager.LoadScene("Menu");
            }

            /// <summary>
            /// Metodo per ricaricare la scena, azzerando anche i valori di Checkpoint e FallInHole
            /// </summary>
            public void ReloadScene()
            {
                Checkpoint.CountCheckpoint = 0;
                FallInHole.CountFall = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            #endregion
            #region Checkpoint Management
            /// <summary>
            /// Metodo per detectare se il player finisce il percorso, aumentando il conteggio
            /// </summary>
            public void DetectWin()
            {
                if(Checkpoint.isWin == true)
                {
                    Checkpoint.isWin = false;
                    CountWin++;
                    CheckpointText.text = "Path Finished: " + CountWin.ToString();
                }
            }
            #endregion
            #endregion
        }
    }
}