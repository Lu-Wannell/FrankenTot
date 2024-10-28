using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyPuzzleController : MonoBehaviour
{
    public bool isPieceOneCorrect = false;
    public bool isPieceTwoCorrect = false;
    public bool isPieceThreeCorrect = false;
    public bool isPieceFourCorrect = false;

    public bool isAtOrigin; //Tracks if the frame is at it's starting point
   
    public Vector3 startPos;

    [SerializeField]
    public GameObject draw;
    private bool drawOpen;

    public void Start()
    {
        
    }

    public void StudyPuzzleChecker()
    {
        // checks if both frames are placed in the correct target position then the puzzle frame moves to reveal a key
        if (isPieceOneCorrect && isPieceTwoCorrect && isPieceThreeCorrect && isPieceFourCorrect)
        {
            drawOpen=true;
            draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);

        }

        
        
           if (!isPieceOneCorrect || !isPieceTwoCorrect || !isPieceThreeCorrect || !isPieceFourCorrect)
            {
                drawOpen = false;
                draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);
                // StartCoroutine(MoveFrame(endPos, startPos, moveTime));
                Debug.Log("Frame Moved back");
            }

    }
}
