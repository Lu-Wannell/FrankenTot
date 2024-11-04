using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalResetLever : Interactable
{
    [SerializeField]
    ChemicalMixer chemicalMixer;

    private float resetfillAmount;

    public void Awake()
    {
        resetfillAmount = chemicalMixer.mixerFillAmount;
    }

    protected override void Interact()
    {
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
