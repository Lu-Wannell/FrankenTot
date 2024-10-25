using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyPuzzleController : MonoBehaviour
{
    public bool isPieceOneCorrect = false;
    public bool isPieceTwoCorrect = false;
    public bool isPieceThreeCorrect = false;
    public bool isPieceFourCorrect = false;

    public GameObject movingBookCase;

    public bool isAtOrigin; //Tracks if the frame is at it's starting point
   
    public Vector3 startPos;

    public void Start()
    {
        startPos = movingBookCase.transform.position;
    }

    public void StudyPuzzleChecker()
    {
        // checks if both frames are placed in the correct target position then the puzzle frame moves to reveal a key
        if (isPieceOneCorrect && isPieceTwoCorrect && isPieceThreeCorrect && isPieceFourCorrect)
        {
            isAtOrigin = false;
            movingBookCase.GetComponent<Animator>().SetBool("isAtOrigin", isAtOrigin);

        }

        
        if (movingBookCase.transform.position != startPos)
        {
            if (!isPieceOneCorrect || !isPieceTwoCorrect || !isPieceThreeCorrect || !isPieceFourCorrect)
            {
                isAtOrigin = true;
                movingBookCase.GetComponent<Animator>().SetBool("isAtOrigin", isAtOrigin);
                // StartCoroutine(MoveFrame(endPos, startPos, moveTime));
                Debug.Log("Frame Moved back");
            }

        }
        else
        {

        }
    }
}
