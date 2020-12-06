using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    namespace WoodenLabyrinth
    {
        /// <summary>
        /// Script per far funzionare il progetto anche su pc
        /// </summary>
        public class RotateLabyrinth : MonoBehaviour
        {
            public float SpeedRotation = 90;                                                //Inizializzo la velocità di rotazione
        
            void FixedUpdate()
            {
                float h = Input.GetAxis("Horizontal");                                      //Setto il valore h tramite l'asse orizzontale
                float v = Input.GetAxis("Vertical");                                        //Setto il valore v tramite l'asse verticale
                transform.Rotate(Vector3.right * SpeedRotation * Time.deltaTime * v);       //Ruoto il labirinto in base al vettore direzione destra e all'asse verticale
                transform.Rotate(Vector3.back * SpeedRotation * Time.deltaTime * h);        //Ruoto il labirinto in base al vettore direzione indietro e all'asse orizzontale
            }
        
    }
}
}
