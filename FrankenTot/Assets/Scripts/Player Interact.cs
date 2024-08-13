using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private float interactRange = 3f;
    [SerializeField]
    private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        cam = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //creates ray at the center of the camera, shooting forwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * interactRange, Color.blue);

        RaycastHit hitInfo; //stores collision information
        if( Physics.Raycast(ray, out hitInfo, interactRange, mask)) //code only runs if raycast hits something
        {

        }
    }
}
