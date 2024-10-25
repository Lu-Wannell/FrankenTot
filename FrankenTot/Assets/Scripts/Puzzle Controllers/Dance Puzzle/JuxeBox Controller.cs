using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuxeBoxController : Interactable
{

    [SerializeField]
    private FirstPersonControls firstPersonControls;
    [SerializeField]
    private DanceFloorChecker danceFloorChecker;

    [SerializeField]
    public bool isJukeboxOn = false;
    [SerializeField]
    public bool hasAllGears = false;

    public void Update()
    {
        if (hasAllGears)
        {
            promptMessage = "Play Music";
        }
    }

    protected override void Interact()
    {
        if (hasAllGears)
        {
            isJukeboxOn = true;
            danceFloorChecker.isDanceFloorOn = true;

        }
        else
        {
            promptMessage = "It Won't Start";
            isJukeboxOn = false;
            danceFloorChecker.isDanceFloorOn = false;
        }

        
            
    }
}
