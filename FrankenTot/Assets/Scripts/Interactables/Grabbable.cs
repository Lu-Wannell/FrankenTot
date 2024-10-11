using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable
{
    protected override void Interact()
    {
        promptMessage = "Hold";
    }
}
