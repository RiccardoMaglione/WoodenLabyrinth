using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    namespace WoodenLabyrinth
    {
        public class Accelerometer : MonoBehaviour
        {
            #region Variables
            public float Speed = 250;                                                                           //Inizializzo la velocità
            public float Sensibility = 5;                                                                       //Inizializzo la sensibilità
            Rigidbody rb;                                                                                       //Inizializzo il rigidbody
            #endregion
                
                    #region Lifecycle
            void Start()
            {
                rb = GetComponent<Rigidbody>();                                                                 //Trovo il componente rigidbody
                Sensibility = PlayerPrefs.GetInt("Sensibility");                                                //Prendo la sensibility del menù delle opzioni e la setto
            }

            void Update()
            {
                if(Application.platform == RuntimePlatform.Android)                                             //Se mi trovo in un ambiente android
                {
                    Vector3 MovementBall = new Vector3(Input.acceleration.x, 0, Input.acceleration.y);          //Calcolo il vettore movimento con i valori dell'accelerometro
                    rb.AddForce(MovementBall * Speed * Sensibility * Time.deltaTime);                           //Applico una forza alla pallina per muoverla
                }
            }
            #endregion
        
        }
    }
}