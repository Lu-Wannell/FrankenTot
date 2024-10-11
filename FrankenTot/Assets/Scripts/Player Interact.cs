using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Title: Raycast Interactions:Let's make a first person game in Unity
// Author: Natty GameDev
// Date: 14 August 2024
// Code Version: 1.0
// Availability: www.youtube.com/watch?v=gPPGnpV1Y1c

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private float interactRange = 3f;

    [SerializeField]
    private float interactBuffer = 1f;

    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;
    private FirstPersonControls firstPersonControls;



    // Start is called before the first frame update
    void Start()
    {
        cam = cam.GetComponent<Camera>();
        playerUI = GetComponent<PlayerUI>();
        firstPersonControls = GetComponent<FirstPersonControls>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        playerUI.UpdateUItoEmpty();

        //creates ray at the center of the camera, shooting forwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * interactRange, Color.blue);

        RaycastHit hitInfo; //stores collision information
        if( Physics.Raycast(ray, out hitInfo, interactRange, mask)) //code only runs if raycast hits something
        {
            //Checks to see if gameobject has an interactable component
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                //Stores interactable in a variable
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
          
                //updates onscreen text to match the prompt message of the interactable
                playerUI.UpdateText(interactable.promptMessage);
                playerUI.UpdateUItoLMB();


                if(firstPersonControls.playerActions.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
