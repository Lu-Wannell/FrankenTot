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

            instance = Instantiate(spawnedPotion);

            // set new held Object
            firstPersonControls.heldObject = instance;
            Debug.Log(firstPersonControls.heldObject.name);
            // Attach the frame to the hold position
            instance.transform.position = firstPersonControls.holdPosition.position;
            //heldObject.transform.rotation = holdPosition.rotation;
            instance.transform.parent = firstPersonControls.holdPosition;

            instance.GetComponent<Rigidbody>().isKinematic = true; // Disable physics of Spawned potion

        }
    }
}
