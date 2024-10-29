using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{

    [SerializeField]
    private GameObject bookShelf;

    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private MoverScript bookShelfMover;
    [SerializeField]
    private MoverScript shelfMover;

    [SerializeField]
    private bool isBookPlaced = false;
    [SerializeField]
    private bool isCorrectBook = false;


    [SerializeField]
    private GameObject placedBook;
    [SerializeField]
    private GameObject correctBook;

    [SerializeField]
    private Transform bookTarget;


    protected override void Interact() // interacting with book moves a bookshelf
    {
        
        if (!isBookPlaced)
        {
            //Checks if player is holding one of two frames
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.tag == "Book")
            {
                //if placing the Ftot Frame at the 1962 plaque sets the bool to true
                if (firstPersonControls.heldObject == correctBook)
                {
                    isCorrectBook = true;

                    
                }                              

                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = bookTarget.position;
                firstPersonControls.heldObject.transform.rotation = (bookTarget.rotation);
                firstPersonControls.heldObject.transform.parent = bookTarget;

                firstPersonControls.heldObject = null; // The player is no longer holding the frame

                isBookPlaced = true;
                promptMessage = "Take Book";
                

            }
            else
            {
                promptMessage = "Book Needed";
            }
        }

        //If the player Interacts with a placed frame and are not holding anything they can then take the frame
        else
        {
            if (firstPersonControls.heldObject == null)
            {
                if (placedBook == correctBook)
                {
                    
                }
                else
                    

                // set new held Object
                firstPersonControls.heldObject = placedBook;
                // Attach the book to the hold position
                placedBook.transform.position = firstPersonControls.holdPosition.position;
                //heldObject.transform.rotation = holdPosition.rotation;
                placedBook.transform.parent = firstPersonControls.holdPosition;
                placedBook = null;

                //frame is no longer placed
                isBookPlaced = false;

                promptMessage = "Place Book";

                
            }
            else
            {
                promptMessage = "Drop Item to Take Book";
            }

        }

    }

    private IEnumerator PlacedCorrectBook()
    {
        yield return new WaitForSecondsRealtime(1f);
    }

    private IEnumerator RemovedCorrectBook()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
