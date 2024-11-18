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
    public GameObject instanceOne;

    [SerializeField]
    private AudioSource grabChemicalAudio;

    protected override void Interact()
    {
        if (firstPersonControls.heldObject == null) 
        {
            if (instanceOne != null)
            {
                Destroy(instanceOne);                
            }

            grabChemicalAudio.Play();
            instanceOne = Instantiate(spawnedPotion);

            // set new held Object
            firstPersonControls.heldObject = instanceOne;
            Debug.Log(firstPersonControls.heldObject.name);
            // Attach the frame to the hold position
            instanceOne.transform.position = firstPersonControls.holdPosition.position;
            //heldObject.transform.rotation = holdPosition.rotation;
            instanceOne.transform.parent = firstPersonControls.holdPosition;

            instanceOne.GetComponent<Rigidbody>().isKinematic = true; // Disable physics of Spawned potion

        }
    }
}
