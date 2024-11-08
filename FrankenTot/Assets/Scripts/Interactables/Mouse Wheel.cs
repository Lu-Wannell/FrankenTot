using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWheel : Interactable
{

    [SerializeField]
    FirstPersonControls firstPersonControls;

    [SerializeField]
    BombPuzzleController bombPuzzleController;

    [SerializeField]
    GameObject mouseWheel;

    [SerializeField]
    GameObject mouse;

    private bool isMousePlaced = false;

    public void Start()
    {
        mouse.SetActive(false);
        promptMessage = "A Mouse Wheel";
    }

    protected override void Interact()
    {
        if (!isMousePlaced) 
        {


            if (firstPersonControls.heldObject.name == "Wriggling Mouse(Clone)")
            {
                Destroy(firstPersonControls.heldObject);
                firstPersonControls.heldObject = null;
                mouseWheel.GetComponent<Animator>().SetBool("RatPlaced", true);
                mouse.SetActive(true);
                bombPuzzleController.isMousePlaced = true;
                bombPuzzleController.BombChecker();
            }
        }
        else
        {
            promptMessage = "You don't want to Interupt it";
        }
        
    }
}
