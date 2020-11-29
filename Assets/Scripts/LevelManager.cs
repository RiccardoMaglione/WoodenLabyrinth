using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject Ball;
    public Material ShaderXRayMaterial;
    private void Update()
    {
        if (PlayerPrefs.GetInt("ActiveShaderXray") == 1)
        {
            Material[] matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
            matArrayStandard[1] = ShaderXRayMaterial;
        }
        if (PlayerPrefs.GetInt("ActiveShaderXray") == 0)
        {
            Material[] matArrayChange = Ball.GetComponent<MeshRenderer>().materials;
            Destroy(matArrayChange[1]);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
