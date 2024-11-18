using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerCompartment : Interactable
{
    [SerializeField]
    private bool isClosed = true;

    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private Rigidbody rigidBody;

    [SerializeField]
    private AudioSource speakerCompartmentAudio;
    public void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
    }
    protected override void Interact()
    {
        if (isClosed == false)
        {
            promptMessage = "A Speaker";
        }
        else
        {
            //if the player is holding the crowbar  then they can open the vent
           // if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.name == "Crusty Crowbar")
            //{
                
                rigidBody.isKinematic = false;
                speakerCompartmentAudio.Play();
                promptMessage = "A Speaker";
                isClosed = false;

            /*}
            else
            {
                 //vent remains closed if you dont have the crowbar
                promptMessage = "It looks like it can be pryed open";
            }*/
        }
    }
           
}
