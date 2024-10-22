using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DanceFloorChecker : MonoBehaviour
{
    private DanceFloorController danceFloorController;
    private bool isDancing;
    public bool isDanceFloorOn = false;

    public void OnTriggerEnter(Collider collider)
    {
        if (!isDancing)
        { return; }


         if (gameObject.name == "DanceFloor")
         {
            isDancing = true;
         }
          
         if(isDancing)
         {
            danceFloorController.currentDance = danceFloorController.currentDance + gameObject.name;
        }
         else
         {
             
         }
         
    }
    public void OnTriggerExit(Collider collider)
    {
        if (gameObject.name == "DanceFloor")
        {
            danceFloorController.currentDance = "" ;
            isDancing = false ;
        }
            
    }


}
