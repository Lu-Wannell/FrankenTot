using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickUp : Interactable
{
    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private GameObject runningMouse;
    [SerializeField]
    private GameObject heldMouse;

    [SerializeField]
    private GameObject heldMouseInstance;

    protected override void Interact()
    {
        if (firstPersonControls.heldObject == null)
        {

            heldMouseInstance = Instantiate(heldMouse);
            runningMouse.SetActive(false);

            // set new held Object
            firstPersonControls.heldObject = heldMouseInstance;
            Debug.Log(firstPersonControls.heldObject.name);
            // Attach the frame to the hold position
            heldMouseInstance.transform.position = firstPersonControls.holdPosition.position;
            //heldObject.transform.rotation = holdPosition.rotation;
            heldMouseInstance.transform.parent = firstPersonControls.holdPosition;

            heldMouseInstance.GetComponent<Rigidbody>().isKinematic = true; // Disable physics of Spawned potion

        }
        else { promptMessage = "Drop held Item"; }
    }
}
