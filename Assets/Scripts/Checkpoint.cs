using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    #region Variables
    public int IDCheckpoint;
    public static int CountCheckpoint;
    public static bool[] isEnter = new bool[8];
    public bool[] InspectorIsEnter = new bool[8];
    public bool[] InspectorCheckpointArray = new bool[8];
    public static bool isWin = false;
    public static bool[] CheckpointArray = new bool[8];
    #endregion
    public static bool CanGo = true;
    private void Start()
    {
        for (int i = 0; i < CheckpointArray.Length; i++)
        {
            isEnter[i] = true;
            CheckpointArray[i] = false;
        }
    }

    void Update()
    {
        //for (int i = 0; i < CheckpointArray.Length; i++)               
        //{
        //    if(CheckpointArray[i] == true)                            
        //    {
        //        if(CheckpointArray[CheckpointArray.Length-1] == true && CountCheckpoint == CheckpointArray.Length)  
        //        {
        //            print("Hai vinto");
        //            isWin = true;
        //            for (int k = 0; k < CheckpointArray.Length; k++)    
        //            {
        //                CheckpointArray[k] = false;       
        //                isEnter[k] = true;
        //                CountCheckpoint = 0;
        //            }
        //        }
        //    }
        //    else
        //    {                                                           
        //        if(CheckpointArray[CheckpointArray.Length-1] == true)
        //        {
        //            for (int j = 0; j < CheckpointArray.Length; j++)
        //            {
        //                print("Hey");
        //                CheckpointArray[j] = false;
        //                isEnter[i] = true;
        //                CountCheckpoint = 0;
        //            }
        //        }
        //    }
        //}
        for (int n = 0; n < CheckpointArray.Length; n++)
        {
            InspectorCheckpointArray[n] = CheckpointArray[n];
        }
        for (int n = 0; n < isEnter.Length; n++)
        {
            InspectorIsEnter[n] = isEnter[n];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BallPlayer" && isEnter[IDCheckpoint] == true)
        {
            for (int i = 0; i < CheckpointArray.Length; i++)
            {

                if(this.IDCheckpoint == i && this.IDCheckpoint != 7)
                {
                    print("Hey2");
                    isEnter[IDCheckpoint] = false;
                    CheckpointArray[IDCheckpoint] = true;
                    CountCheckpoint++;
                    print(CountCheckpoint);
                }
                if (7 == this.IDCheckpoint)
                {
                    CheckpointArray[IDCheckpoint] = true;
                    if (CheckpointArray[i] == true)                            
                    {
                        if(CheckpointArray[CheckpointArray.Length-1] == true && CountCheckpoint == CheckpointArray.Length-1)  
                        {
                            print("Hai vinto");
                            isWin = true;
                            for (int k = 0; k < CheckpointArray.Length; k++)    
                            {
                                CheckpointArray[k] = false;       
                                isEnter[k] = true;
                                CountCheckpoint = 0;
                            }
                        }
                        else
                        {
                            if (CheckpointArray[CheckpointArray.Length - 1] == true && CountCheckpoint != CheckpointArray.Length - 1)
                            {
                                for (int j = 0; j < CheckpointArray.Length; j++)
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
        //else
        //{
        //    print("Hey3" + isEnter);
        //}
    }
}