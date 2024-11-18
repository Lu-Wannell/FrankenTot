using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPedastal : Interactable
{
    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private SkullPuzzleController skullPuzzleController;

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

    [SerializeField]
    private int skullAngle = 0;

    [SerializeField]
    private int skullTargetAngle;

    [SerializeField]
    public bool isSkullCorrect = false;

    [SerializeField]
    private AudioSource skullPedastalAudioSource;


    protected override void Interact()
    {
        if(skullRotator.isRotating) { return; }

        if (!skullPlaced) {
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == (SkullOne || SkullTwo))
            {
                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = skullTarget.position;
                firstPersonControls.heldObject.transform.rotation = (skullTarget.rotation);
                firstPersonControls.heldObject.transform.parent = skullTarget;

                firstPersonControls.heldObject.layer = 0;

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
            promptMessage = "Rotate Skull";
            skullRotator.RotateObject();
            skullPedastalAudioSource.Play();
            skullAngle = skullAngle + 45;
            if (skullAngle == 360)
            {
                skullAngle = 0;
            }
            if (skullAngle == skullTargetAngle)
            {
                isSkullCorrect = true;                
                skullPuzzleController.SkullChecker();
            }
            else
            { 
                isSkullCorrect = false;               
                skullPuzzleController.SkullChecker();
            }

        }
        
    }
}
