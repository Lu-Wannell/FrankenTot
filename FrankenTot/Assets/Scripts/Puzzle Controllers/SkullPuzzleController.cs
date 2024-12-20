using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPuzzleController : MonoBehaviour
{
    [SerializeField]
    private SkullPedastal pedastalOne;
    [SerializeField]
    private SkullPedastal pedastalTwo;
    [SerializeField]
    private SkullPedastal pedastalThree;

    [SerializeField]
    public GameObject draw;
    private bool allSkullsCorrect = false;

    [SerializeField]
    private MoverScript drawMover;

    [SerializeField]
    private AudioSource longDrawAudio;


    public void SkullChecker()
    {
        if (pedastalOne.isSkullCorrect && pedastalTwo.isSkullCorrect && pedastalThree.isSkullCorrect)
        {
            drawMover.MoveObject();
            longDrawAudio.Play();
            allSkullsCorrect = true;
        }

        else
        {
            if (allSkullsCorrect == true)
            {
                drawMover.MoveBack();
                longDrawAudio.Play();
                allSkullsCorrect = false;
            }
            
        }
    }
}
