using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{

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
        if (bookShelfMover.isMoving || shelfMover.isMoving)
        {
            return;
        }


        if (!isBookPlaced)
        {
            //Checks if player is holding a book
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.tag == "Book")
            {                          

                if (firstPersonControls.heldObject.name != "Dorian Grey Special Book")
                {
                    promptMessage = "Different book needed";
                    return;
                }


                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = bookTarget.position;
                firstPersonControls.heldObject.transform.rotation = (bookTarget.rotation);
                firstPersonControls.heldObject.transform.parent = bookTarget;

                placedBook = firstPersonControls.heldObject;

                if (placedBook == correctBook)
                {
                    isCorrectBook = true;
                    StartCoroutine(PlacedCorrectBook());
                    Debug.Log("placedBook");

                }

                firstPersonControls.heldObject = null; // The player is no longer holding the frame

                isBookPlaced = true;
                promptMessage = "Take Book";
                

            }
            else
            {
                promptMessage = "Book Needed";
            }
        }

        //If the player Interacts with a placed book and are not holding anything they can then take the frame
        else
        {
            if (firstPersonControls.heldObject == null)
            {
                if (placedBook == correctBook)
                {
                    StartCoroutine(RemovedCorrectBook());
                }
                    

                // set new held Object
                firstPersonControls.heldObject = placedBook;
                // Attach the book to the hold position
                placedBook.transform.position = firstPersonControls.holdPosition.position;
                //heldObject.transform.rotation = holdPosition.rotation;
                placedBook.transform.parent = firstPersonControls.holdPosition;
                placedBook = null;

                //book is no longer placed
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
        shelfMover.MoveObject();
        yield return new WaitForSecondsRealtime(1f);
        bookShelfMover.MoveObject();
    }

    private IEnumerator RemovedCorrectBook()
    {
        bookShelfMover.MoveBack();
        yield return new WaitForSecondsRealtime(3f);
        shelfMover.MoveBack();
    }
}
