using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloorController : MonoBehaviour
{

    public bool isPuzzleOneDone = false;
    public bool isPuzzleTwoDone = false;
    public bool isPuzzleThree_OneDone = false;
    public bool isPuzzleThree_TwoDone = false;
    public bool isPuzzleThree_ThreeDone = false;

    public string sequenceOne = "874563";
    public string sequenceTwo = "47896321";
    public string sequenceThree = "7412369";
    public string sequenceFour = "6587";
    public string sequenceFive = "45";

    public string currentDance = "";


    public void DanceSequenceCheck()
    {
        //Check first sequence
        if (!isPuzzleOneDone)
        {
            if (currentDance == sequenceOne)
            {
                isPuzzleOneDone = true;
            }
        }

        // check second sequence
        if (!isPuzzleTwoDone)
        {
            if (currentDance == sequenceTwo)
            {
                isPuzzleTwoDone = true;
            }
        }

        // check third Sequence
        if (!isPuzzleThree_OneDone)
        {
            if (currentDance == sequenceThree)
            {
                isPuzzleThree_OneDone = true;
                currentDance = "";
            }
        }

        // check fourth Sequence
        if (!isPuzzleThree_TwoDone)
        {
            if (currentDance == sequenceFour)
            {
                isPuzzleThree_TwoDone = true;
                currentDance = "";
            }
        }

        // check fifth Sequence
        if (!isPuzzleThree_ThreeDone)
        {
            if (currentDance == sequenceFive)
            {
                isPuzzleThree_ThreeDone = true;
            }    
        }
    }
}
