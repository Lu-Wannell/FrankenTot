using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    [SerializeField]
    private GameObject draw;
    private bool drawOpen;
    private bool isMoving = false;

    [SerializeField]
    private AudioSource drawerAudio;


    protected override void Interact()
    {
        if (isMoving) { return; }

        isMoving = true;
        drawOpen = !drawOpen;//Changes the bool whenever the draw is interacted with
        draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);
        drawerAudio.Play();

        promptMessage = "";

        StartCoroutine(Wait());    

        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2f);
        isMoving = false;

        if (drawOpen)
        { promptMessage = "Close Draw"; }
        else
        { promptMessage = "Open Draw"; }
    }
}