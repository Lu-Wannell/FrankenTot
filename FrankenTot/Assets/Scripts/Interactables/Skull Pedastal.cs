using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPedastal : Interactable
{
    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private RotatorScript skullRotator;

    [SerializeField]
    private bool skullPlaced;

    [SerializeField]
    private GameObject SkullOne;
    [SerializeField]
    private GameObject SkullTwo;

    [SerializeField]
    private Transform skullTarget;


    protected override void Interact()
    {
        if (!skullPlaced) {
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == (SkullOne || SkullTwo))
            {
                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = skullTarget.position;
                firstPersonControls.heldObject.transform.rotation = (skullTarget.rotation);
                firstPersonControls.heldObject.transform.parent = skullTarget;

                firstPersonControls.heldObject = null;

                skullPlaced = true;
                promptMessage = "Rotate Skull";
            }
            else
            {
                promptMessage = "Place Skull";
            }
        }
        else
        {
            skullRotator.RotateObject();
        }
        
    }
}
