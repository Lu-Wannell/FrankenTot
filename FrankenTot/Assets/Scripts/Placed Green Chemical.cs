using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedGreenChemical : MonoBehaviour
{


    [SerializeField]
    private ChemicalGrower jimmyGrower;

    [SerializeField]
    private GeneralInteractable jimmyInteractable;

    [SerializeField]
    private GameObject PlacedGrowthChemical;

    private bool hasGrownComplete = false;



    public void Awake()
    {
        PlacedGrowthChemical.SetActive(false);
    }

    public void Update()
    {
        if (hasGrownComplete)
        { return; }

        if(jimmyGrower.hasGrown)
        {
            jimmyInteractable.myBool = true;
            PlacedGrowthChemical.SetActive(true);
            hasGrownComplete = true;
        }
    }

}





    