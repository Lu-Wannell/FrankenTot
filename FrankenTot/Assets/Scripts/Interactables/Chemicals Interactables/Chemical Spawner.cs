using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalSpawner : Interactable
{
    [SerializeField]
    private FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject spawnedPotion;

    [SerializeField]
    public GameObject instance;

    protected override void Interact()
    {
        if (firstPersonControls.heldObject == null) 
        {
            if (instance != null)
            {
                Destroy(instance);                
            }

            Instantiate(spawnedPotion);

            // set new held Object
            firstPersonControls.heldObject = spawnedPotion;
            // Attach the frame to the hold position
            spawnedPotion.transform.position = firstPersonControls.holdPosition.position;
            //heldObject.transform.rotation = holdPosition.rotation;
            spawnedPotion.transform.parent = firstPersonControls.holdPosition;
            


            instance = spawnedPotion;
        }
    }
}
