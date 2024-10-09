using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : Interactable
{
    [SerializeField]
    private GameObject ventCover;
    [SerializeField]
    private bool ventClosed = true;
    public FirstPersonControls firstPersonControls;
    [SerializeField]
    private float moveAmount = 6f;
    [SerializeField]
    private float moveSpeed;
    private bool isMoving;



    protected override void Interact()
    {

        if (!isMoving) // Prevent triggering multiple rotations simultaneously
        {
            //if a door isn't locked it switches between opened and closed
            if (!ventClosed)
            {                   
                    promptMessage = "";
            }
            else
            {
                //if the player is holding the crowbar  then they can open the vent
                if (firstPersonControls.heldObject != null && firstPersonControls.heldObject.name == "Crusty Crowbar")
                {
                    ventClosed = false;
                    OpenVent();
                    promptMessage = "";

                }
                else
                {
                    ventClosed = true; //vent remains closed if you dont have the crowbar
                    promptMessage = "It looks like it can be pryed open";
                }
            }
        }
        else
        {
            return;
        }

    }

    public void OpenVent()
    {

        StartCoroutine(moveVentOpen(ventCover, moveAmount));

    }

    private IEnumerator moveVentOpen(GameObject ventCover, float moveAmount)
    {
        promptMessage = "";
        isMoving = true;
        Vector3 startPosition = ventCover.transform.position; // Initial  rotation
        Vector3 endPosition = startPosition - new Vector3(moveAmount, 0, 0);
        // Target rotation
        float moveProgress = 0f;

        while (moveProgress < 1f)
        {
            moveProgress += Time.deltaTime * (moveSpeed / moveAmount); // Normalize the move speed based on move amount
            ventCover.transform.position = Vector3.Lerp(startPosition,
            endPosition, moveProgress); // Smoothly interpolate movement
            yield return null;
        }
        ventCover.transform.position = endPosition; // Ensure exact final position
        isMoving = false;

    }

   
}


