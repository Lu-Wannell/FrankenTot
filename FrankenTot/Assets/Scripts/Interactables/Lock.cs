using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Interactable
{
    public FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject chestKey;

    [SerializeField]
    private Chest chest;

    public void Awake()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
    }

    protected override void Interact()
    {
        //if a chest is unlocked it switches between the open and closed state
        if (!chest.chestLocked)
        {
           
                promptMessage = "A Lock";
        }

        //You can only open the chest if it is locked while holding the key
        else
        {
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == chestKey)
            {

                //Chest is unlocked
                chest.chestLocked = false;
                promptMessage = "A Lock";
                gameObject.GetComponent<Rigidbody>().isKinematic = false; //disable physics

            }
            else
            {
                //chest remains locked
                chest.chestLocked = true;
                promptMessage = "It's Locked";
            }
        }

    }
}
