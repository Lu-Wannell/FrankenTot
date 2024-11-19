using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChemicalGrower : Interactable
{
    [SerializeField]
    FirstPersonControls firstPersonControls;

    [SerializeField]
    GameObject startingPlant;
    [SerializeField]
    GameObject grownPlant;

    [SerializeField]
    Transform player;
    [SerializeField]
    Transform grownPlayerTarget;

    [SerializeField]
    public bool hasGrown = false;

    [SerializeField]
    private string grownPrompt;


    [SerializeField]
    private GameObject growParticles;

    [SerializeField]
    private Transform growParticlesTarget;

    [SerializeField]
    private AudioSource growAudio;

    public void Awake()
    {
        grownPlant.SetActive(false);
    }

    protected override void Interact()
    {
        if (hasGrown)
        {
            promptMessage = grownPrompt;
            return;
        }

        if (firstPersonControls.heldObject.name == "Green Chemical(Clone)")
        {
            StartCoroutine(GrowPlant());
        }
       
    }

    private IEnumerator GrowPlant()
    {
        growAudio.Play();
        Destroy(firstPersonControls.heldObject);
        firstPersonControls.heldObject = null;
        hasGrown = true;
        Instantiate(growParticles, growParticlesTarget);

        yield return new WaitForSecondsRealtime(1f);
        startingPlant.SetActive(false);
        grownPlant.SetActive(true);
        player.position = grownPlayerTarget.position;
        promptMessage = grownPrompt;
        
        yield return new WaitForSecondsRealtime(1f);
        //Destroy(growParticles);

    }
}
