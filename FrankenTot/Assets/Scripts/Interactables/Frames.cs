using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Frames : Interactable
{
    [SerializeField]
    private GameObject plaque1948;
    [SerializeField]
    private GameObject plaque1962;
    [SerializeField]
    private Transform frameTarget;
    [SerializeField]
    private GameObject fTotFrame;
    [SerializeField]
    private GameObject harvardFrame;

    private GameObject placedFrame;


    private bool framePlaced = false;
    public TutorialRoomPuzzleController tutorialRoomPuzzleController;
    public FirstPersonControls firstPersonControls;

   
    

    protected override void Interact()
    {
        // Debug.Log(firstPersonControls.heldObject);
        if (!framePlaced)
        {
            //Checks if player is holding one of two frames
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == (fTotFrame || harvardFrame)) 
                
            {
                //if holding the Ftot Frame sets the bool to true
                if(firstPersonControls.heldObject == fTotFrame && gameObject == plaque1962)
                {
                    tutorialRoomPuzzleController.isFTotFrameCorrect = true;
                    placedFrame = fTotFrame;
                }
                else if(firstPersonControls.heldObject == harvardFrame && gameObject == plaque1948)
                {
                    tutorialRoomPuzzleController.isDegreeFrameCorrect = true;
                    placedFrame = harvardFrame;
                }
                else if (firstPersonControls.heldObject == fTotFrame)
                {
                    placedFrame = fTotFrame;
                }
                else
                {
                    placedFrame = harvardFrame;
                }

                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
               // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = frameTarget.position;
                firstPersonControls.heldObject.transform.rotation = (frameTarget.rotation);
                firstPersonControls.heldObject.transform.parent = frameTarget;

                firstPersonControls.heldObject = null; // The player is no longer holding the frame

                framePlaced = true;
                promptMessage = "Take Frame";

                tutorialRoomPuzzleController.TutorialPuzzleChecker();

            }
            else
            {
                promptMessage = "Frame Needed";
            }
        }
        else
        {
            if(firstPersonControls.heldObject == null)
            {
                if(placedFrame == harvardFrame)
                {
                    tutorialRoomPuzzleController.isDegreeFrameCorrect = false;
                }
                else
                    tutorialRoomPuzzleController.isFTotFrameCorrect = false;

                // set new held Object
                firstPersonControls.heldObject = placedFrame;
                // Attach the object to the hold position
                placedFrame.transform.position = firstPersonControls.holdPosition.position;
                //heldObject.transform.rotation = holdPosition.rotation;
                placedFrame.transform.parent = firstPersonControls.holdPosition;
                placedFrame = null;

                //frame is no longer placed
                framePlaced = false;

                promptMessage = "Frame Needed";

                tutorialRoomPuzzleController.TutorialPuzzleChecker();
            }
            else
            {
                promptMessage = "Drop Items to Take Frame";
            }
                
        }

    }
}
