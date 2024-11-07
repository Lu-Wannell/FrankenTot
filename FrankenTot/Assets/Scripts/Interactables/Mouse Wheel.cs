using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWheel : Interactable
{

    [SerializeField]
    FirstPersonControls firstPersonControls;

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
            }
        }
        else
        {
            promptMessage = "You don't want to Interupt it";
        }
        
    }
}
