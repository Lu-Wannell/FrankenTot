using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class FavCreationFrame : Interactable
{

    protected override void Interact()
    {
         promptMessage = "It Won't budge";
         //resetPromtMessage();
         
    }
     
    private IEnumerator resetPromtMessage()
    {
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime;
        }
        promptMessage = "A Picture Frame";
        yield return null;

    }
}