using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : Interactable
{

    [SerializeField]
    private FirstPersonControls firstPersonControls;

    [SerializeField]
    private JuxeBoxController jukeBoxController;


    [Header("Gear Info")]
    [Space(7)]
    [SerializeField]
    private bool hasGearOne = false;
    [SerializeField]
    private bool hasGearTwo = false;


    [SerializeField]
    private GameObject GearOne;
    [SerializeField]
    private GameObject GearTwo;


    public Transform gearTargetOne;
    public Transform gearTargetTwo;


    protected override void Interact()
    {
        hasGearOne = true;
        hasGearTwo = true;
        if (hasGearOne && hasGearTwo)
        {
            jukeBoxController.hasAllGears = true;
        }
        
    }
}

