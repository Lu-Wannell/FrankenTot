using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPuzzleController : MonoBehaviour
{
    [SerializeField]
    private bool isSkullOneCorrect = false;
    [SerializeField]
    private bool isSkullTwoCorrect = false;
    [SerializeField]
    private bool isSkullThreeCorrect = false;

    [SerializeField]
    public GameObject draw;
    private bool drawOpen;


    private void SkullChecker()
    {
        if (isSkullOneCorrect && isSkullTwoCorrect && isSkullThreeCorrect)
        {
            drawOpen = true;
            draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);
        }

        else
        {
            drawOpen = false;
            draw.GetComponent<Animator>().SetBool("drawOpen", drawOpen);
        }
    }
}
