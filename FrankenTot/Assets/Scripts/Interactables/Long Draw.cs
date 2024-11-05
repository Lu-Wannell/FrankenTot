using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDraw : Interactable
{
    [SerializeField]
    private GameObject draw;
    private bool drawOpen;

    [SerializeField]
    private float moveAmount = 6f;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool hasMoved = true;

    [SerializeField]
    private AudioSource longDrawAudio;

    protected override void Interact()
    {
        if (hasMoved == false)
        {
            return;
        }

        drawOpen = !drawOpen;//Changes the bool whenever the draw is interacted with

        if (drawOpen)
        { 
            promptMessage = "Close Draw"; 
            StartCoroutine(moveDraw(draw, moveAmount));
        }
        else
        { 
            promptMessage = "Open Draw";
            StartCoroutine(moveDraw(draw, -moveAmount));
        }
    }

    private IEnumerator moveDraw(GameObject draw, float moveAmount)
    {
        hasMoved = false;
        Vector3 startPosition = draw.transform.position; // Initial  position
        Vector3 endPosition = startPosition + new Vector3(moveAmount, 0, 0);

        float moveProgress = 0f;

        longDrawAudio.Play();

        while (moveProgress < 1f)
        {
            moveProgress += Time.deltaTime * (moveSpeed / Mathf.Abs(moveAmount)); // Normalize the move speed based on move amount
            draw.transform.position = Vector3.Lerp(startPosition,
            endPosition, moveProgress); // Smoothly interpolate movement
            yield return null;
        }
        draw.transform.position = endPosition; // Ensure exact final position
        hasMoved = true;
    }
}
