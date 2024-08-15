using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private GameObject chest;
    private bool chestLocked = true;
    private bool chestOpen;
    private FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject chestKey;

    protected override void Interact()
    {
        Debug.Log(firstPersonControls.heldObject);
        if (!chestLocked)
            {
               chestOpen = !chestOpen;
               chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
            }
        else
        {
           if ( firstPersonControls.heldObject == chestKey)
            {
                chestOpen = !chestOpen;
                chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
                chestLocked = false;
            }
            else
            {

            }
        }

    }
}