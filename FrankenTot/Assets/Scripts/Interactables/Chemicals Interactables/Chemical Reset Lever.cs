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

    private bool isRotating = false;
    

    public void Awake()
    {
        resetfillAmount = chemicalMixer.mixerFillAmount;
    }

    protected override void Interact()
    {
        if (isRotating || leverRotatorScript.isRotating) 
        {
            return;
        }

        isRotating = true;

        leverRotatorScript.RotateObject();
        StartCoroutine(WaitTwoSeconds());


        chemicalMixer.firstChemicalColor = Color.magenta;
        chemicalMixer.secondChemicalColor = Color.magenta;
        chemicalMixer.thirdChemicalColor = Color.magenta;
        chemicalMixer.mixerFillAmount = resetfillAmount;
        chemicalMixer.mixer.transform.position = chemicalMixer.chemMixerStartingPos;
        //chemicalMixer.material.SetFloat("_Fill", resetfillAmount);
        chemicalMixer.chemicalCount = 0;
        chemicalMixer.promptMessage = "chemical Needed";
        chemicalMixer.material.SetColor("_TopColour", chemicalMixer.invisible);

    }

    private IEnumerator WaitTwoSeconds()
    { 
        yield return new WaitForSecondsRealtime(2f);
        leverRotatorScript.RotateBack();
        isRotating = false;
    }

}