using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BombChip : Interactable
{
    public FirstPersonControls firstPersonControls;

    [SerializeField]
    private BombPuzzleController bombPuzzleController;

    [SerializeField]
    private GameObject bombChip;

    [SerializeField]
    private Transform bombChipTarget;

    private bool isPlaced = false;

    protected override void Interact()
    {
        if(isPlaced)
        {
            return;
        }

        if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == bombChip)
        {
            firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                         // Attach the object to the target position
            firstPersonControls.heldObject.transform.position = bombChipTarget.position;
            firstPersonControls.heldObject.transform.rotation = bombChipTarget.rotation;
            firstPersonControls.heldObject.transform.parent = bombChipTarget;
            bombChip.GetComponent<BoxCollider>().enabled = false;
            firstPersonControls.heldObject = null; // The player is no longer holding the bomb chip
            isPlaced = true;
            bombPuzzleController.isBombChipPlaced = true;
            bombPuzzleController.BombChecker();
            

            promptMessage = "The Bomb Chip";
        }
        else
        {

            promptMessage = "Something's Missing";
        }        
    }
}
