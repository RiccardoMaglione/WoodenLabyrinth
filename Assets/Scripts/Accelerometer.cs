using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public float Speed = 250;
    public float Sensibility = 5;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sensibility = PlayerPrefs.GetInt("Sensibility");
    }

    void Update()
    {
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 MovementBall = new Vector3(h, 0, v);
            rb.AddForce(MovementBall * Speed * Time.deltaTime);
        }
        if(Application.platform == RuntimePlatform.Android)
        {
            Vector3 MovementBall = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);
            rb.AddForce(MovementBall * Speed * Sensibility * Time.deltaTime);
        }
    }
}
