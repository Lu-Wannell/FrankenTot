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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        jukeBoxController.hasAllGears = true;
    }
}

