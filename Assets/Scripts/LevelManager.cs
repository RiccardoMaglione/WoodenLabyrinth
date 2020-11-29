using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject Ball;
    public Material NormalMaterial;
    public Material ShaderXRayMaterial;
    Material[] matArrayStandard;

    private void Update()
    {
        if (PlayerPrefs.GetInt("ActiveShaderXray") == 1)
        {
            matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
            matArrayStandard[1] = ShaderXRayMaterial;
            Ball.GetComponent<MeshRenderer>().materials = matArrayStandard;
            print("1");
        }
        if (PlayerPrefs.GetInt("ActiveShaderXray") == 0)
        {
            matArrayStandard = Ball.GetComponent<MeshRenderer>().materials;
            matArrayStandard[1] = NormalMaterial;
            Ball.GetComponent<MeshRenderer>().materials = matArrayStandard;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReloadScene()
    {
        FallInHole.CountFall = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
