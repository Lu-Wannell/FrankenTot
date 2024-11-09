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
    private GameObject danceOnSign;
    [SerializeField] 
    private GameObject danceOffSign;

    [SerializeField]
    public bool isJukeboxOn = false;
    [SerializeField]
    public bool hasAllGears = false;

    [SerializeField]
    private AudioSource danceAudio;

    [SerializeField]
    private bool isAudioPlaying = false;

    public void Update()
    {
        if (hasAllGears)
        {
            if (isAudioPlaying)
            {
                promptMessage = "Stop Music";
            }
            else
            {
                promptMessage = "Play Music";
            }
            
        }
    }

    protected override void Interact()
    {
        if (hasAllGears)
        {
            isJukeboxOn = true;
            danceOnSign.SetActive(true);
            danceOffSign.SetActive(false);
            danceFloorChecker.isDanceFloorOn = true;
            if (!isAudioPlaying)
            { 
                danceAudio.Play();
                isAudioPlaying = true;
            }
            else
            {
                danceAudio.Stop();
                isAudioPlaying = false;
            }

        }
        else
        {
            promptMessage = "It Won't Start";
            isJukeboxOn = false;
            danceFloorChecker.isDanceFloorOn = false;
        }

        
            
    }
}
