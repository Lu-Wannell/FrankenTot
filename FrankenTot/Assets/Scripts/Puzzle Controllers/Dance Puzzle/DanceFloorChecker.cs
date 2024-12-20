using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DanceFloorChecker : MonoBehaviour
{
    [SerializeField]
    private DanceFloorController danceFloorController;
    [SerializeField] 
    private DanceLightsController danceLightsController;    
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

                collider.gameObject.GetComponentInChildren < Light>(true).enabled = true;

                // add current dance step to current dance
                string currentStep = collider.name;
                danceFloorController.currentDance = danceFloorController.currentDance + currentStep;

                //Check if the current dance sequence matches the required sequence.
                danceFloorController.DanceSequenceCheck();
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
            danceLightsController.DisableLights();
            danceFloorController.isPuzzleThree_OneDone = false;
            danceFloorController.isPuzzleThree_TwoDone = false;

        }
            
    }


}
