using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombPuzzleController : MonoBehaviour
{
    [SerializeField]
    PlayerUI playerUI;
    public string EndScene;

    public bool isMousePlaced = false;
    public bool isPurpleChemPlaced = false;
    public bool isBombChipPlaced = false;

    public bool isBombComplete = false;
    public bool isEndingTriggered;

    public void BombChecker()
    {
        if (isMousePlaced && isPurpleChemPlaced && isBombChipPlaced) 
        {
            isBombComplete = true;
            isEndingTriggered = true;            
        }

        if (isEndingTriggered)
        {
            playerUI.EndScreenActive();
            SceneManager.LoadScene(EndScene);            
        }
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
