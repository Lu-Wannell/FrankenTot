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
        drawOpen = !drawOpen;//Changes the bool whenever the draw is interacted with
        draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);

        if (drawOpen)
        { promptMessage = "Close Draw"; }
        else
        { promptMessage = "Open Draw"; }
    }
}