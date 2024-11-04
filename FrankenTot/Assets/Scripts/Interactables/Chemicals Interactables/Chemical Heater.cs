using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalHeater : Interactable
{
    [SerializeField]
    private FirstPersonControls firstPersonControls;

    public Transform chemicalTarget;
    public GameObject placedChemical;
    public GameObject heatedChemical;

    [SerializeField]
    private GameObject redChemical;
    [SerializeField]
    private GameObject orangeChemical;
    [SerializeField]
    private GameObject blackChemical;

    [SerializeField]
    private GameObject instanceRed;
    [SerializeField]
    private GameObject instanceOrange;
    [SerializeField]
    private GameObject instanceBlack;

    private bool isChemicalPlaced;
    private bool isHeating;

    protected override void Interact()
    {
        if(isHeating)
        {
            promptMessage = "It's too hot to hold";
            return;
        }
        else
        {
            
                if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.tag != "Chemical")
                {
                    promptMessage = "Chemical needed";
                    return;
                }
                       

            if(isChemicalPlaced)
            {
                // set new held Object
                firstPersonControls.heldObject = heatedChemical;
                // Attach the frame to the hold position
                heatedChemical.transform.position = firstPersonControls.holdPosition.position;
                //heldObject.transform.rotation = holdPosition.rotation;
                heatedChemical.transform.parent = firstPersonControls.holdPosition;
                heatedChemical = null;

                //chemical is no longer placed
                isChemicalPlaced = false;
            }
            else
            {
                if (firstPersonControls.heldObject == null)
                {
                    promptMessage = "Chemical Needed";
                    return; 
                }

                isHeating = true;
                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = chemicalTarget.position;
                firstPersonControls.heldObject.transform.rotation = (chemicalTarget.rotation);
                firstPersonControls.heldObject.transform.parent = chemicalTarget;

                placedChemical = firstPersonControls.heldObject;
                firstPersonControls.heldObject = null; // The player is no longer holding the chemical
                

                isChemicalPlaced = true;
                StartCoroutine(HeatTimer());

                
            }
        }
    }

    private IEnumerator HeatTimer()
    {
        
        yield return new WaitForSecondsRealtime(3f);
        isHeating = false;
        HeatChemical();
    }

    private void HeatChemical()
    {
        if (placedChemical.name == "White Chemical(Clone)")
        {          
            if (instanceRed != null)
            {
                Destroy(instanceRed);               
            }

            Destroy(placedChemical);
            instanceRed = Instantiate(redChemical);
            heatedChemical = instanceRed;
        }
        else if (placedChemical.name == "Yellow Chemical(Clone)")
        {
            if (instanceOrange != null)
            {
                Destroy(instanceOrange);
            }

            Destroy(placedChemical);
            instanceOrange = Instantiate(orangeChemical);
            heatedChemical = instanceOrange;
        }
        else
        {
            if (instanceBlack != null)
            {
                Destroy(instanceBlack);
            }

            Destroy(placedChemical);
            instanceBlack = Instantiate(blackChemical);
            heatedChemical = instanceBlack;
        }

        heatedChemical.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                     // Attach the object to the target position
        heatedChemical.transform.position = chemicalTarget.position;
        heatedChemical.transform.rotation = (chemicalTarget.rotation);
        heatedChemical.transform.parent = chemicalTarget;
        promptMessage = "Take Chemical";
    }
}
