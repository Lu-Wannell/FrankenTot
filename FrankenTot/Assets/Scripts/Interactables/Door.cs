using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorLocked = true;
    private bool doorOpen;
    public FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject doorKey;

    protected override void Interact()
    {
        // Debug.Log(firstPersonControls.heldObject);
        if (!doorLocked)
        {
            doorOpen = !doorOpen;
            door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
            if (doorOpen)
            { promptMessage = "Close Door"; }
            else
            { promptMessage = "Open Door"; }
        }
        else
        {
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == doorKey)
            {
                doorOpen = !doorOpen;
                door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
                doorLocked = false;
                promptMessage = "Close Door";

            }
            else
            {
                doorLocked = true;
                promptMessage = doorKey.name+ " Needed";
            }
        }

    }
}
