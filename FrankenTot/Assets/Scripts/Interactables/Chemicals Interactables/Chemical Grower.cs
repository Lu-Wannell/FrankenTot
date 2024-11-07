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
    private bool hasGrown = false;

    [SerializeField]
    private string grownPrompt;

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
        Destroy(firstPersonControls.heldObject);
        firstPersonControls.heldObject = null;
        startingPlant.SetActive(false);
        grownPlant.SetActive(true);

        player.position = grownPlayerTarget.position;
        yield return null;
    }
}
