using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalResetLever : Interactable
{
    [SerializeField]
    ChemicalMixer chemicalMixer;

    [SerializeField]
    private RotatorScript leverRotatorScript;

    private float resetfillAmount;

    public void Awake()
    {
        resetfillAmount = chemicalMixer.mixerFillAmount;
    }

    protected override void Interact()
    {
        if (leverRotatorScript.isRotating) 
        {
            return;
        }

        leverRotatorScript.RotateObject();

        int wait = 0;
        while (leverRotatorScript.isRotating)
        {
            wait++;
        }

        leverRotatorScript.RotateBack();

        chemicalMixer.firstChemicalColor = Color.magenta;
        chemicalMixer.secondChemicalColor = Color.magenta;
        chemicalMixer.thirdChemicalColor = Color.magenta;
        chemicalMixer.mixerFillAmount = resetfillAmount;
        chemicalMixer.material.SetFloat("_Fill", resetfillAmount);
        chemicalMixer.chemicalCount = 0;
        chemicalMixer.promptMessage = "chemical Needed";
        chemicalMixer.material.SetColor("_TopColour", chemicalMixer.invisible);

    }
}
