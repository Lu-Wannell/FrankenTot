using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private bool doorLocked = true;
    [SerializeField]
    private bool doorOpen;
    public FirstPersonControls firstPersonControls;
    [SerializeField]
    private GameObject doorKey;
    [SerializeField]
    private float rotateAmount = 90f;
    [SerializeField]
    private float rotationSpeed;
    private bool isRotating;


    public void Start()
    {
        gameObject.GetComponent<Door>().enabled = true;
    }

    protected override void Interact()
    {
        if (gameObject.GetComponent<Door>().enabled == false)
        {
            return;
        }

        if (!isRotating) // Prevent triggering multiple rotations simultaneously
        {
            //if a door isn't locked it switches between opened and closed
            if (!doorLocked)
            {
                doorOpen = !doorOpen;
                // door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
                if (doorOpen)
                {
                    OpenDoor();
                    promptMessage = "Close Door";
                }
                else
                {
                    CloseDoor();
                    promptMessage = "Open Door";
                }
            }
            else
            {
                //if the player is holding the correct key for a locked door then they can unlock it and open it
                if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == doorKey)
                {
                    doorOpen = !doorOpen;
                    // door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
                    OpenDoor();
                    doorLocked = false; //  door is now unlocked
                    promptMessage = "Close Door";

                }
                else
                {
                    doorLocked = true; //door remains locked if you dont have the correct key
                    promptMessage = doorKey.name + " Needed";
                }
            }
        }
        else
        {
            return;
        }
            // Debug.Log(firstPersonControls.heldObject);

            

    }

    public void OpenDoor()
    {
        
            StartCoroutine(RotateDoorOpen(door, rotateAmount));
        
    }

    public void CloseDoor()
    {
        
            StartCoroutine(RotateDoorClosed(door, rotateAmount));
        
    }

    private IEnumerator RotateDoorOpen(GameObject door, float angle)
    {
        promptMessage = "";
        isRotating = true;
        Quaternion startRotation = door.transform.rotation; // Initial  rotation
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, angle);
        // Target rotation
        float rotationProgress = 0f;

        while (rotationProgress < 1f)
        {
            rotationProgress += Time.deltaTime * (rotationSpeed / angle); // Normalize the rotation speed based on angle
            door.transform.rotation = Quaternion.Lerp(startRotation,
            endRotation, rotationProgress); // Smoothly interpolate rotation
            yield return null;
        }
        door.transform.rotation = endRotation; // Ensure exact final rotation
        isRotating = false;

    }

    private IEnumerator RotateDoorClosed(GameObject door, float angle)
    {
        promptMessage = "";
        isRotating = true;
        Quaternion startRotation = door.transform.rotation; // Initial  rotation
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, -angle);
        // Target rotation
        float rotationProgress = 0f;

        while (rotationProgress < 1f)
        {
            rotationProgress += Time.deltaTime * (rotationSpeed / angle); // Normalize the rotation speed based on angle
            door.transform.rotation = Quaternion.Lerp(startRotation,
            endRotation, rotationProgress); // Smoothly interpolate rotation
            yield return null;
        }
        door.transform.rotation = endRotation; // Ensure exact final rotation
        isRotating = false;

    }
}
