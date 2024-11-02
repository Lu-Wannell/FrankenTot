using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalSpawner : Interactable
{
    private FirstPersonControls firstPersonControls;
    private GameObject spawnedPotion;

    public static GameObject instance;

    protected override void Interact()
    {
        if (firstPersonControls.heldObject == null) 
        {
            Instantiate(spawnedPotion);

        }
    }
}
