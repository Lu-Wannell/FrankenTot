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
       //if a chest is unlocked it switches between the open and closed state
        if (!chestLocked)
        {
             chestOpen = !chestOpen;
             chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
             if(chestOpen)
             { promptMessage = "Close Chest"; }
             else
             { promptMessage = "Open Chest"; }
        }

        //You can only open the chest if it is locked while holding the key
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
                chestLocked = true;
                promptMessage = "Key Needed";
            }
        }

    }
}