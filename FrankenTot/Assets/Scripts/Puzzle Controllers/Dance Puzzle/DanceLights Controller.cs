using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceLightsController : MonoBehaviour
{
    [SerializeField]
    private Light light1;
    [SerializeField]
    private Light light2;
    [SerializeField]
    private Light light3;
    [SerializeField]
    private Light light4;
    [SerializeField]
    private Light light5;
    [SerializeField]
    private Light light6;
    [SerializeField]
    private Light light7;
    [SerializeField]
    private Light light8;
    [SerializeField]
    private Light light9;

    private Color successColor;
    private Color normalColor;

    public void Awake()
    {
        DisableLights();
        successColor = Color.green;
        normalColor = Color.white;
        NormalLights();
    }


    public void CompletePuzzleLights()
    {
        StartCoroutine(PuzzleSuccess());
    }

    public void PuzzleThree_PartOne()
    {
        DisableLights();
        light9.enabled = true;
    }
    public void PuzzleThree_PartTwo()
    {
        DisableLights();
        light7.enabled = true;
    }

    IEnumerator PuzzleSuccess()
    {
        EnableLights();
        SuccessLights();

        yield return new WaitForSeconds(1);

        NormalLights();
        DisableLights();
        
    }



    public void DisableLights()
    {
        light1.enabled = false;
        light2.enabled = false;
        light3.enabled = false;
        light4.enabled = false;
        light5.enabled = false;
        light6.enabled = false;
        light7.enabled = false;
        light8.enabled = false;
        light9.enabled = false;
    }

    private void EnableLights()
    {
        light1.enabled = true;
        light2.enabled = true;
        light3.enabled = true;
        light4.enabled = true;
        light5.enabled = true;
        light6.enabled = true;
        light7.enabled = true;
        light8.enabled = true;
        light9.enabled = true;
    }

    private void SuccessLights()
    {
        light1.color = successColor;
        light2.color = successColor;
        light3.color = successColor;
        light4.color = successColor;
        light5.color = successColor;
        light6.color = successColor;
        light7.color = successColor;
        light8.color = successColor;
        light9.color = successColor;

    }

    private void NormalLights()
    {
        light1.color = normalColor;
        light2.color = normalColor;
        light3.color = normalColor;
        light4.color = normalColor;
        light5.color = normalColor;
        light6.color = normalColor;
        light7.color = normalColor;
        light8.color = normalColor;
        light9.color = normalColor;
    }
}
