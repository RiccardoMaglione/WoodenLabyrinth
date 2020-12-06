using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaglioneFramework
{
    namespace WoodenLabyrinth
    {
        public class FallInHole : MonoBehaviour
        {
            #region Variables
            public static int CountFall = 0;                                    //Inizializzo il conteggio delle cadute
            bool isEnter = false;                                               //Inizializzo il booleano che indica se può entrare e conteggiare la caduta
            public Text FallText;                                               //Inizializzo il testo che indica al giocatore quanto volte è caduto
            #endregion

            private void OnTriggerEnter(Collider other)
            {
                if(isEnter == false)                                            //Se è falso
                {
                    CountFall += 1;                                             //Aumento di uno il numero delle cadute
                    isEnter = true;                                             //Setto a vero per fare in modo che il count fall non salga ulteriormente
                    StartCoroutine(Timer());                                    //Faccio partire la coroutine
                    FallText.text = "Fall in Hole: " + CountFall.ToString();
                }
                print("CountFall" + CountFall);
            }
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(5);
                isEnter = false;                                                //Setto a falso per detectare una prossima caduta nella stessa buca
            }
        }
    }
}