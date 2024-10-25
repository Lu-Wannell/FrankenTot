using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitPieces : Interactable
{
    [SerializeField]
    private GameObject portraitTarget1;
    [SerializeField]
    private GameObject portraitTarget2;
    [SerializeField]
    private GameObject portraitTarget3;
    [SerializeField]
    private GameObject portraitTarget4;



    [SerializeField]
    private GameObject portraitPiece1;
    [SerializeField]
    private GameObject portraitPiece2;
    [SerializeField]
    private GameObject portraitPiece3;
    [SerializeField]
    private GameObject portraitPiece4;

    [SerializeField]
    private GameObject placedPortrait;

    [SerializeField]
    private bool portraitPlaced = false;
    public StudyPuzzleController studyPuzzleController;
    public FirstPersonControls firstPersonControls;




    protected override void Interact()
    {
        // Debug.Log(firstPersonControls.heldObject);
        if (!portraitPlaced)
        {
            //Checks if player is holding one of four pieces
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == 
                (portraitPiece1 || portraitPiece2 || portraitPiece3 || portraitPiece4))

            {
                //if placing the Portrait 1 at the Portrait 1 position sets the bool to true
                if (firstPersonControls.heldObject == portraitPiece1 && gameObject == portraitTarget1)
                {
                    studyPuzzleController.isPieceOneCorrect = true;
                    placedPortrait = portraitPiece1;
                }
                //if placing the Portrait 2 at the Portrait 2 position sets the bool to true
                else if (firstPersonControls.heldObject == portraitPiece2 && gameObject == portraitTarget2)
                {
                    studyPuzzleController.isPieceTwoCorrect = true;
                    placedPortrait = portraitPiece2;
                }
                //if placing the Portrait 3 at the Portrait 3 position sets the bool to true
                else if (firstPersonControls.heldObject == portraitPiece3 && gameObject == portraitTarget3)
                {
                    studyPuzzleController.isPieceThreeCorrect = true;
                    placedPortrait = portraitPiece3;
                }
                //if placing the Portrait 4 at the Portrait 4 position sets the bool to true
                else if (firstPersonControls.heldObject == portraitPiece4 && gameObject == portraitTarget4)
                {
                    studyPuzzleController.isPieceFourCorrect = true;
                    placedPortrait = portraitPiece4;
                }
                else
                {
                    placedPortrait = firstPersonControls.heldObject;
                }

                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = gameObject.transform.position;
                firstPersonControls.heldObject.transform.rotation = (gameObject.transform.rotation);
                firstPersonControls.heldObject.transform.parent = gameObject.transform;

                firstPersonControls.heldObject = null; // The player is no longer holding the frame

                portraitPlaced = true;
                promptMessage = "Take Portrait Piece";

                //Every time a frame is placed it updates the puzzlecontroller bools
                studyPuzzleController.StudyPuzzleChecker();

            }
            else
            {
                promptMessage = "Portrait Piece Needed";
            }
        }

        //If the player Interacts with a placed frame and are not holding anything they can then take the frame
        else
        {
            if (firstPersonControls.heldObject == null)
            {
                if (placedPortrait == portraitPiece1)
                {
                    studyPuzzleController.isPieceOneCorrect = false;
                }
                else if (placedPortrait == portraitPiece2)
                {
                    studyPuzzleController.isPieceTwoCorrect = false;
                }
                else if (placedPortrait == portraitPiece3)
                {
                    studyPuzzleController.isPieceThreeCorrect = false;
                }
                else
                {
                    studyPuzzleController.isPieceFourCorrect = false;
                }

                // set new held Object
                firstPersonControls.heldObject = placedPortrait;
                // Attach the frame to the hold position
                placedPortrait.transform.position = firstPersonControls.holdPosition.position;
                //heldObject.transform.rotation = holdPosition.rotation;
                placedPortrait.transform.parent = firstPersonControls.holdPosition;
                placedPortrait = null;

                //frame is no longer placed
                portraitPlaced = false;

                promptMessage = "Place Frame";

                //Every time a frame is Taken it updates the puzzlecontroller bools
                studyPuzzleController.StudyPuzzleChecker();
            }
            else
            {
                promptMessage = "Drop Item to Take Piece";
            }

        }

    }
}
