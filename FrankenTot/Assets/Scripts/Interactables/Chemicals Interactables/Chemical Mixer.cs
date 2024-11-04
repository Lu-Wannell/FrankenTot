using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalMixer : Interactable
{

    [SerializeField]
    FirstPersonControls firstPersonControls;
    [SerializeField]
    PotionPuzzleController potionPuzzleController;
    [SerializeField]
    GameObject chemicalMixer;

    private float chemicalCount;

    private bool willFail;
    protected override void Interact()
    {
        if(firstPersonControls.heldObject != null) 
        { 
            if (firstPersonControls.heldObject.name == "White Chemical(Clone)")
            {
                Debug.Log("Let's Gooooo");
            }
        }
    }
}
