using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    [SerializeField]
    private GameObject draw;
    private bool drawOpen;

    protected override void Interact()
    {
        drawOpen = !drawOpen;
        draw.GetComponent<Animator>().SetBool("isOpen", drawOpen);

        if (drawOpen)
        { promptMessage = "Close Draw"; }
        else
        { promptMessage = "Open Draw"; }
    }
}