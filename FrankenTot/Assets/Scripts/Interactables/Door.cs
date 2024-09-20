using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private bool doorLocked = true;
    private bool doorOpen;
    public FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject doorKey;
    

    protected override void Interact()
    {


        // Debug.Log(firstPersonControls.heldObject);

        //if a door isn't locked it switches between opened and closed
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
            //if the player is holding the correct key for a locked door then they can unlock it and open it
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == doorKey)
            {
                doorOpen = !doorOpen;
                door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
                doorLocked = false; //  door is now unlocked
                promptMessage = "Close Door";

            }
            else
            {
                doorLocked = true; //door remains locked if you dont have the correct key
                promptMessage = doorKey.name+ " Needed";
            }
        }

    }
}
