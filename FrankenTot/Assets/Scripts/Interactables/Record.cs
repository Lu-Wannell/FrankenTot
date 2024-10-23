using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : Interactable
{
    [SerializeField]
    private GameObject hintRecord;

    [SerializeField]
    private Animator record;

    [SerializeField]
    private GameObject GramophoneTop;
    [SerializeField]
    private Animator gramophone;

    [SerializeField]
    private Transform recordTarget;


    private bool recordPlaced = false;
    //public GramophoneController gramophoneController;
    public FirstPersonControls firstPersonControls;
    private bool isPlaying = false;



    protected override void Interact()
    {
        // if the record isn't placed
        if (!recordPlaced)
        {
            //Checks if player is holding the hintRecord
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == hintRecord)

            {
               

                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = recordTarget.position;
                firstPersonControls.heldObject.transform.rotation = (recordTarget.rotation);
                firstPersonControls.heldObject.transform.parent = recordTarget;

                firstPersonControls.heldObject = null; // The player is no longer holding the frame

                recordPlaced = true;
                promptMessage = "Play Record";


            }
            else
            {
                promptMessage = "Place Record";
            }
        }
        //If the player Interacts with the gramophone and it has the record
        else
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                promptMessage = "Play Record";
                

            }
            else
            {
                promptMessage = "Playing";
            }

        }

    }
}
