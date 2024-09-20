using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRoomPuzzleController : MonoBehaviour
{
    public bool isFTotFrameCorrect = false;
    public bool isDegreeFrameCorrect = false;
    public GameObject movingFrame;

    public bool isAtOrigin; //Tracks if the frame is at it's starting point


    //public GameObject target;
    public Vector3 startPos;
    //public Vector3 endPos;
    //float moveTime;

    public void Start()
    {
        startPos= movingFrame.transform.position;
        //endPos= target.transform.position;
    }

    public void TutorialPuzzleChecker()
    {
        // checks if both frames are placed in the correct target position then the puzzle frame moves to reveal a key
        if (isFTotFrameCorrect && isDegreeFrameCorrect)
        {
            isAtOrigin = false; 
            movingFrame.GetComponent<Animator>().SetBool("isAtOrigin", isAtOrigin);

            Debug.Log("Frame Moved");
        }

        // checks if both frames are placed in the correct target position then the puzzle frame moves to reveal a key
        if (movingFrame.transform.position != startPos)
        {
            if (!isFTotFrameCorrect || !isDegreeFrameCorrect)
            {
                isAtOrigin = true;
                movingFrame.GetComponent<Animator>().SetBool("isAtOrigin", isAtOrigin);
                // StartCoroutine(MoveFrame(endPos, startPos, moveTime));
                Debug.Log("Frame Moved back");
            }
            
        }
        else
        {
            
        }



        /* if (movingFrame.transform.position != startPos)
         {
             if (!isFTotFrameCorrect || !isDegreeFrameCorrect)
             {
                // StartCoroutine(MoveFrame(endPos, startPos, moveTime));
                 Debug.Log("Frame Moved back");
             }
         }
         else
         {
             if (isFTotFrameCorrect && isDegreeFrameCorrect)
             {
                // StartCoroutine(MoveFrame(startPos, endPos, moveTime));
                 Debug.Log("Frame Moved");
             }
         }*/

    }

   /* IEnumerator MoveFrame(Vector3 startPos, Vector3 endPos, float time)
    {
        for(float t = 0; t < 1; t += Time.deltaTime / time)
        {
            movingFrame.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }
    }*/
}
