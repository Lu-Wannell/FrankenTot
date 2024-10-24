using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : Interactable
{
    [SerializeField]
    private GameObject hintRecord;

    [SerializeField]
    private Animator record;

    [SerializeField]
    private GameObject GramophoneTop;
    [SerializeField]
    private Animator gramophone;

    [SerializeField]
    private Transform recordTarget;


    private bool recordPlaced = false;
    //public GramophoneController gramophoneController;
    public FirstPersonControls firstPersonControls;
    private bool isPlaying = false;


    [Header("Audio Parameters")]
    [Space(7)]
    [SerializeField]
    private AudioSource gramophoneAudio;
    private float audioLength;


    public void Start()
    {
        audioLength = gramophoneAudio.clip.length;
    }


    protected override void Interact()
    {
        // if the record isn't placed
        if (!recordPlaced)
        {
            //Checks if player is holding the hintRecord
            if (firstPersonControls.heldObject != null && firstPersonControls.heldObject == hintRecord)

            {
               

                firstPersonControls.heldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physics
                                                                                             // Attach the object to the target position
                firstPersonControls.heldObject.transform.position = recordTarget.position;
                firstPersonControls.heldObject.transform.rotation = (recordTarget.rotation);
                firstPersonControls.heldObject.transform.parent = recordTarget;

                firstPersonControls.heldObject = null; // The player is no longer holding the frame

                recordPlaced = true;
                promptMessage = "Play Record";


            }
            else
            {
                promptMessage = "Place Record";
            }
        }
        //If the player Interacts with the gramophone and it has the record
        else
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                promptMessage = "Playing";
                gramophone.GetComponent<Animator>().SetBool("isPlaying", true);
                StartCoroutine(PlayAudio() );


            }
            else
            {
                promptMessage = "Playing";
            }

        }

    }

    private IEnumerator PlayAudio()
    {
        yield return new WaitForSecondsRealtime(3f);
        gramophoneAudio.Play();

        yield return new WaitForSecondsRealtime(audioLength);

        record.GetComponent<Animator>().SetBool("isSpinning", false);
        gramophone.GetComponent<Animator>().SetBool("isPlaying", false);

        yield return new WaitForSecondsRealtime(2f);

        isPlaying = false;
        promptMessage = "Play Record";

    }
}
