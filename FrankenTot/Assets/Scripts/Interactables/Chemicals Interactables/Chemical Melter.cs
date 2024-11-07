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

    public void Awake()
    {
        startingObject.SetActive(false);
    }

    protected override void Interact()
    {
        if (hasMelted)
        {
            promptMessage = meltedPrompt;
            return;
        }

        if (firstPersonControls.heldObject.name == "Pink Chemical(Clone)")
        {
            StartCoroutine(GrowPlant());
        }

    }

    private IEnumerator GrowPlant()
    {
        Destroy(firstPersonControls.heldObject);
        firstPersonControls.heldObject = null;
        startingObject.SetActive(false);
        meltedObject.SetActive(true);
        
        yield return null;
    }
}
