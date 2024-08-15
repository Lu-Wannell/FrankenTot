using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private GameObject chest;
    private bool chestLocked;
    private bool chestOpen;
    private FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject chestKey;

    protected override void Interact()
    {

            if (!chestLocked)
        {
            chestOpen = !chestOpen;
            chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
        }
        else
        {
            if (firstPersonControls.heldObject == chestKey)
            {
                chestOpen = !chestOpen;
                chest.GetComponent<Animator>().SetBool("isOpen", chestOpen);
            }
            else
            {

            }
        }

    }
}