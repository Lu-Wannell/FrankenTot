using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private LayerMask mask;
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = cam.GetComponent<Camera>();
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        //creates ray at the center of the camera, shooting forwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * interactRange, Color.blue);

        RaycastHit hitInfo; //stores collision information
        if( Physics.Raycast(ray, out hitInfo, interactRange, mask)) //code only runs if raycast hits something
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
