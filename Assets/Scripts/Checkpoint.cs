using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    #region Variables
    public int IDCheckpoint;
    public static int CountCheckpoint;
    bool isEnter = true;
    public bool[] InspectorCheckpointArray = new bool[8];
    public static bool isWin = false;
    public static bool[] CheckpointArray = new bool[8];
    #endregion

    private void Start()
    {
        for (int i = 0; i < CheckpointArray.Length; i++)
        {
            CheckpointArray[i] = false;
        }
    }

    void Update()
    {
        for (int i = 0; i < CheckpointArray.Length; i++)               
        {
            if(CheckpointArray[i] == true)                            
            {
                if(CheckpointArray[CheckpointArray.Length-1] == true && CountCheckpoint == CheckpointArray.Length)  
                {
                    print("Hai vinto");
                    isWin = true;
                    for (int k = 0; k < CheckpointArray.Length; k++)    
                    {
                        CheckpointArray[IDCheckpoint] = false;       
                        isEnter = true;
                        CountCheckpoint = 0;
                    }
                }
            }
            else
            {                                                           
                if(CheckpointArray[CheckpointArray.Length-1] == true)
                {
                    for (int j = 0; j < CheckpointArray.Length; j++)
                    {
                        CheckpointArray[IDCheckpoint] = false;
                        isEnter = true;
                        CountCheckpoint = 0;
                    }
                }
            }
        }
        for (int n = 0; n < CheckpointArray.Length; n++)
        {
            InspectorCheckpointArray[n] = CheckpointArray[n];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "BallPlayer" && isEnter == true)
        {
            for (int i = 0; i < CheckpointArray.Length; i++)
            {
                if(this.IDCheckpoint == i)
                {
                    isEnter = false;
                    CheckpointArray[IDCheckpoint] = true;
                    CountCheckpoint++;
                    print(CountCheckpoint);
                }
            }
        }
    }
}