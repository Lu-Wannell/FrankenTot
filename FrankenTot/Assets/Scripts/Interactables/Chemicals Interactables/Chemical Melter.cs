using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalMelter : Interactable
{
    [SerializeField]
    FirstPersonControls firstPersonControls;

    [SerializeField]
    GameObject startingObject;
    [SerializeField]
    GameObject meltedObject;

    [SerializeField]
    private bool hasMelted = false;

    [SerializeField]
    private string meltedPrompt;

    [SerializeField]
    private GameObject meltParticles;

    [SerializeField]
    private Transform meltParticlesTarget;

    [SerializeField]
    private AudioSource meltAudio;

    public void Awake()
    {
        meltedObject.SetActive(false);
    }

    protected override void Interact()
    {
        if (hasMelted)
        {
            promptMessage = meltedPrompt;
            return;
        }

        promptMessage = "It is stuck in place";

        if (firstPersonControls.heldObject.name == "Pink Chemical(Clone)")
        {
            StartCoroutine(MeltObject());
        }

    }

    private IEnumerator MeltObject()
    { 
        meltAudio.Play();
        Destroy(firstPersonControls.heldObject);
        firstPersonControls.heldObject = null;
        hasMelted = true;
        Instantiate(meltParticles, meltParticlesTarget);

        yield return new WaitForSecondsRealtime(1f);
        startingObject.SetActive(false);
        //meltedObject.SetActive(true);
        
        hasMelted = true;
        yield return new WaitForSecondsRealtime(1f);       
        //Destroy(meltParticles);
    }
}
