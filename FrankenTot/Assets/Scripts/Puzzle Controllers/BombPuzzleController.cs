using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPuzzleController : MonoBehaviour
{
    public bool isMousePlaced = false;
    public bool isPurpleChemPlaced = false;
    public bool isBombChipPlaced = false;

    public bool isBombComplete = false;

    public void BombChecker()
    {
        if (isMousePlaced && isPurpleChemPlaced && isBombChipPlaced) 
        {
            isBombComplete = true;
        }
    }
}
