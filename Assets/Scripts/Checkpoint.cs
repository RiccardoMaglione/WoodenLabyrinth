using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    namespace WoodenLabyrinth
    {
        public class Checkpoint : MonoBehaviour
        {
            #region Variables
            public int IDCheckpoint;                                                //
            public static int CountCheckpoint;                                      //
            public bool[] InspectorIsEnter = new bool[8];                           //
            public bool[] InspectorCheckpointArray = new bool[8];                   //
            public static bool isWin = false;                                       //
            public static bool CanGo = true;                                        //
            public static bool[] isEnter = new bool[8];                             //
            public static bool[] CheckpointArray = new bool[8];                     //
            #endregion

            #region Lifecycle
            private void Start()
            {
                for (int i = 0; i < CheckpointArray.Length; i++)                    //Ciclo for per settare dei valori standard
                {
                    isEnter[i] = true;
                    CheckpointArray[i] = false;
                }
            }

            void Update()
            {
                for (int n = 0; n < CheckpointArray.Length; n++)                    //Ciclo for per vedere da inspector dei valori statici
                {
                    InspectorCheckpointArray[n] = CheckpointArray[n];
                }
                for (int n = 0; n < isEnter.Length; n++)                            //Ciclo for per vedere da inspector dei valori statici
                {
                    InspectorIsEnter[n] = isEnter[n];
                }
            }

            /// <summary>
            /// Verifico se la pallina passa un checkpoint e attraverso l'id verifico di quale si tratta, aumentando o resettando i valori
            /// </summary>
            /// <param name="other"></param>
            private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.name == "BallPlayer" && isEnter[IDCheckpoint] == true)
                {
                    for (int i = 0; i < CheckpointArray.Length; i++)
                    {

                        if(this.IDCheckpoint == i && this.IDCheckpoint != 7)        //Se è qualsiasi checkpoint tranne l'ultimo, in base all'id, non lo identifico più a meno che non ci sia un reset, e aumento il count
                        {
                            print("Hey2");
                            isEnter[IDCheckpoint] = false;
                            CheckpointArray[IDCheckpoint] = true;
                            CountCheckpoint++;
                            print(CountCheckpoint);
                        }
                        if (7 == this.IDCheckpoint)                                 //Se è l'ultimo checkpoint
                        {
                            CheckpointArray[IDCheckpoint] = true;
                            if (CheckpointArray[i] == true)                            
                            {
                                if(CheckpointArray[CheckpointArray.Length-1] == true && CountCheckpoint == CheckpointArray.Length-1)                //Se l'ultimo checkpoint è stato attivato e il count è finito
                                {
                                    print("Hai vinto");
                                    isWin = true;                                                                                                   //Passo il bool che indica la vittoria
                                    for (int k = 0; k < CheckpointArray.Length; k++)                                                                //Resetto i valori di tutti i checkpoint
                                    {
                                        CheckpointArray[k] = false;       
                                        isEnter[k] = true;
                                        CountCheckpoint = 0;
                                    }
                                }
                                else
                                {
                                    if (CheckpointArray[CheckpointArray.Length - 1] == true && CountCheckpoint != CheckpointArray.Length - 1)       //Se l'ultimo checkpoint è stato attivato e il count non è ancora finito
                                    {
                                        for (int j = 0; j < CheckpointArray.Length; j++)                                                            //Resetto i valori di tutti i checkpoint
                                        {
                                            print("Hey");
                                            CheckpointArray[j] = false;
                                            isEnter[i] = true;
                                            CountCheckpoint = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}