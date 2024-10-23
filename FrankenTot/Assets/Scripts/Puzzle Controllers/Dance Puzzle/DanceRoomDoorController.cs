using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DanceRoomDoorController : Interactable
{
    [SerializeField]
    private DanceFloorController danceFloorController;

    [SerializeField]
    private DanceRoomDoorController danceRoomDoorController;

    [SerializeField]
    private Door door;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Door>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (danceFloorController.isPuzzleThree_ThreeDone)
        {
            gameObject.GetComponent<Door>().enabled = true;
            door.OpenDoor();
            Destroy(danceRoomDoorController);
        }
    }

    protected override void Interact()
    {
        promptMessage = "The handle appears to be stuck";

    }
}
