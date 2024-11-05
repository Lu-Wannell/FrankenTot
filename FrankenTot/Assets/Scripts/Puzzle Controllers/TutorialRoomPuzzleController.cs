using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRoomPuzzleController : MonoBehaviour
{
    public bool isFTotFrameCorrect = false;
    public bool isDegreeFrameCorrect = false;
    public GameObject movingFrame;

    public bool isAtOrigin; //Tracks if the frame is at it's starting point

    [SerializeField]
    private AudioSource frameAudio;

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
            frameAudio.Play();

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
    }  
}
