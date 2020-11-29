using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallInHole : MonoBehaviour
{
    public static int CountFall = 0;
    bool isEnter = false;
    public Text FallText;
    private void OnTriggerEnter(Collider other)
    {
        if(isEnter == false)
        {
            CountFall += 1;
            isEnter = true;
            StartCoroutine(Timer());
            FallText.text = "Fall in Hole: " + CountFall.ToString();
        }
        print("CountFall" + CountFall);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        isEnter = false;
    }
}
