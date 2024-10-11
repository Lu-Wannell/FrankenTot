using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    protected override void Interact()
    {
        promptMessage = "Pick-Up";
    }
}
