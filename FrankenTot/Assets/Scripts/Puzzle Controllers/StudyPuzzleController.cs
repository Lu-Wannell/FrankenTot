using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyPuzzleController : MonoBehaviour
{
    public bool isPieceOneCorrect = false;
    public bool isPieceTwoCorrect = false;
    public bool isPieceThreeCorrect = false;
    public bool isPieceFourCorrect = false;
   
    public Vector3 startPos;

    [SerializeField]
    public GameObject draw;
    private bool drawOpen;
    private bool framesCorrect = false;

    [SerializeField]
    private AudioSource drawerAudio;

    public void StudyPuzzleChecker()
    {
        // checks if frames are placed in the correct target position then the puzzle frame moves to reveal a key
        if (isPieceOneCorrect && isPieceTwoCorrect && isPieceThreeCorrect && isPieceFourCorrect)
        {
            drawOpen=true;
            draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);
            drawerAudio.Play();
            framesCorrect=true;

        }

        
        
        if (!isPieceOneCorrect || !isPieceTwoCorrect || !isPieceThreeCorrect || !isPieceFourCorrect)
        {
            drawOpen = false;
            draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);

            if (framesCorrect) 
            {
                drawerAudio.Play();
                framesCorrect = false;
            }
            // StartCoroutine(MoveFrame(endPos, startPos, moveTime));
            Debug.Log("Frame Moved back");
        }

    }
}
