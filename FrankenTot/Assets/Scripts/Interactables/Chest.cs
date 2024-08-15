using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private GameObject chest;
    private bool chestLocked = true;
    private bool chestOpen;
    public FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject chestKey;

    protected override void Interact()
    {
       // Debug.Log(firstPersonControls.heldObject);
        if (!chestLocked)
        {
             chestOpen = !chestOpen;
             chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
             if(chestOpen)
             { promptMessage = "Close Chest"; }
             else
             { promptMessage = "Open Chest"; }
        }
        else
        {
             if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == chestKey)
             {
                chestOpen = !chestOpen;
                chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
                chestLocked = false;
                promptMessage = "Close Chest";

             }
            else
            {
                promptMessage = "Key Needed";
            }
        }

    }
}