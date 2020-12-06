using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public GameObject Ball;
    public Material NormalMaterial;
    public Material ShaderXRayMaterial;
    Material[] matArrayStandard;
    public Text CheckpointText;
    int CountWin;
    private void Update()
    {
        if (PlayerPrefs.GetInt("ActiveShaderXray") == 1)
        {
            matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
            matArrayStandard[1] = ShaderXRayMaterial;
            Ball.GetComponent<MeshRenderer>().materials = matArrayStandard;
            //print("1");
        }
        if (PlayerPrefs.GetInt("ActiveShaderXray") == 0)
        {
            matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
            matArrayStandard[1] = NormalMaterial;
            Ball.GetComponent<MeshRenderer>().materials = matArrayStandard;
        }
        DetectWin();
    }
    #region Function and Method
    #region Scene Management
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReloadScene()
    {
        Checkpoint.CountCheckpoint = 0;
        FallInHole.CountFall = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
    #region Checkpoint Management
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
