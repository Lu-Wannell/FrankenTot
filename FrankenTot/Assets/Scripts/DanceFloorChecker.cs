using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DanceFloorChecker : MonoBehaviour
{
    [SerializeField]
    private DanceFloorController danceFloorController;
    [SerializeField]
    private bool isDancing;
    public bool isDanceFloorOn = false;

    public void OnTriggerEnter(Collider collider)
    {

        if (isDanceFloorOn)
        {
            if (collider.name == "DanceFloor")
            {
                isDancing = true;
                return;
            }

            if (isDancing)
            {                
                string currentStep = collider.name;
                danceFloorController.currentDance = danceFloorController.currentDance + currentStep;
            }
            else
            {

            }

        }
         
    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.name == "DanceFloor")
        {
            danceFloorController.currentDance = "" ;
            isDancing = false ;
        }
            
    }


}
