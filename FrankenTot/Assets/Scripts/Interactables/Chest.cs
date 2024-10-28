using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField]
    private GameObject chest;
    [SerializeField]
    public bool chestLocked = true;
    [SerializeField]
    private bool chestOpen;
    public FirstPersonControls firstPersonControls;
    public RotatorScript chestRotator;
    [SerializeField]
    private GameObject chestKey;

    protected override void Interact()
    {
        if (chestRotator.isRotating == true)
        {
            return;
        }
       //if a chest is unlocked it switches between the open and closed state
        if (!chestLocked)
        {
             chestOpen = !chestOpen;
             
             if(chestOpen)
             {
                chestRotator.RotateObject();
                promptMessage = "Close Chest";
             }         
             else
             {
                chestRotator.RotateBack();
                promptMessage = "Open Chest";
             }
        }

        //You can only open the chest if it is locked while holding the key
        else
        {
           
                //chest remains locked
                chestLocked = true;
                promptMessage = "It's Locked";
            
        }

    }
}