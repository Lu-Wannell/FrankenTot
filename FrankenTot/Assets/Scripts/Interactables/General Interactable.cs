using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInteractable : Interactable
{
    [SerializeField]
    private string interactPrompt;

    [SerializeField]
    private string changedBoolPrompt;

    [SerializeField]
    private bool myBool = false;

    protected override void Interact()
    {
        if (myBool)
        {
            promptMessage = changedBoolPrompt;
            return;
        }

        promptMessage = interactPrompt;
    }
}
