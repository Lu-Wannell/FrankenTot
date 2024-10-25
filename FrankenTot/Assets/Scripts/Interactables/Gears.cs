using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : Interactable
{

    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private JuxeBoxController jukeBoxController;

    [SerializeField]
    private float moveSpeed;

    [Header("Panel Info")]
    [Space(7)]
    [SerializeField]
    private bool isPanelOpen;
    [SerializeField]
    private GameObject panel;


    [Header("Gear Info")]
    [Space(7)]
    [SerializeField]
    private bool hasGearOne = false;
    [SerializeField]
    private bool hasGearTwo = false;
    [SerializeField]
    private bool hasGearThree = false;  


    [SerializeField]
    private GameObject gearOne;
    [SerializeField]
    private GameObject gearTwo;
    [SerializeField]
    private GameObject gearThree;


    public Transform gearTargetOne;
    public Transform gearTargetTwo;
    public Transform gearTargetThree;


    protected override void Interact()
    {

        if (jukeBoxController.hasAllGears)
        {
            return;
        }

        if (!isPanelOpen) 
        {
            panel.GetComponent<Animator>().SetBool("panelOpen", true);
            promptMessage = "Place Gear";
            isPanelOpen = true;
            return;
        }

        if (jukeBoxController.hasAllGears == false)
        {

            if (firstPersonControls.heldObject != null)
            {

                if(firstPersonControls.heldObject == gearOne)
                {
                    hasGearOne = true;
                    PlaceGear(gearTargetOne);
                }
                else if(firstPersonControls.heldObject == gearTwo)
                {
                    hasGearTwo = true;
                    PlaceGear(gearTargetTwo);
                }
                else if(firstPersonControls.heldObject == gearThree)
                {
                    hasGearThree = true;
                    PlaceGear(gearTargetThree);
                }
                else
                {
                
                }

            }
        }
        
        if (hasGearOne && hasGearTwo && hasGearThree)
        {
            jukeBoxController.hasAllGears = true;
            panel.GetComponent<Animator>().SetBool("panelOpen", false);
            promptMessage = "Jukebox Panel";
        }
        
    }


    private void PlaceGear(Transform gearTarget)
    {
        firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                     // Attach the object to the target position
        firstPersonControls.heldObject.transform.position = gearTarget.position;
        firstPersonControls.heldObject.transform.rotation = (gearTarget.rotation);
        firstPersonControls.heldObject.transform.parent = gearTarget;

        firstPersonControls.heldObject = null; // The player is no longer holding the gear

    }

    

}

