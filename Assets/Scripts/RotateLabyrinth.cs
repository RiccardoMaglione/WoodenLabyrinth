using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLabyrinth : MonoBehaviour
{
    public float SpeedRotation = 90;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * SpeedRotation * Time.deltaTime * v);
        transform.Rotate(Vector3.back * SpeedRotation * Time.deltaTime * h);
    }
}
