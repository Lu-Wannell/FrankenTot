using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombChemicalPlacement : Interactable
{
    public FirstPersonControls firstPersonControls;

    [SerializeField]
    private BombPuzzleController bombPuzzleController;

    [SerializeField]
    private GameObject PlacedBombChemical;

    private bool isPlaced = false;

    public void Awake()
    {
        PlacedBombChemical.SetActive(false);
    }

    protected override void Interact()
    {
        if (isPlaced)
        {
            return;
        }

        if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.name == "Purple Chemical(Clone)")
        {
            firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                         // Attach the object to the target position
            Destroy(firstPersonControls.heldObject);
            
            firstPersonControls.heldObject = null; // The player is no longer holding the bomb chip
            isPlaced = true;
            bombPuzzleController.isPurpleChemPlaced = true;
            PlacedBombChemical.SetActive(true);
            bombPuzzleController.BombChecker();


            promptMessage = "The Bomb Chemical";
        }
        else
        {

            promptMessage = "Something's Missing";
        }
    }
}
