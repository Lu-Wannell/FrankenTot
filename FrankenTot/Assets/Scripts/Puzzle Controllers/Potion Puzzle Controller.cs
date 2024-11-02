using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPuzzleController : MonoBehaviour
{
    [Header("Mixed Potions")]
    [Space(7)]  
    //detect if the chemicals have been made
    public bool isPinkChemicalMade = false;
    public bool isBlueChemicalMade = false;
    public bool isGreenChemicalMade = false;
    public bool isPurpleChemicalMade = false;
    public bool isBlackChemicalMade = false;

    //The empty placeHolder flask before the chemical is made
    public GameObject pinkChemicalPlaceHolder;
    public GameObject blueChemicalPlaceHolder;
    public GameObject greenChemicalPlaceHolder;
    public GameObject purpleChemicalPlaceHolder;
    public GameObject blackChemicalPlaceHolder;

    // The filled flask after the chemical has been made
    public GameObject pinkChemicalSpawner;
    public GameObject blueChemicalSpawner;
    public GameObject greenChemicalSpawner;
    public GameObject purpleChemicalSpawner;
    public GameObject blackChemicalSpawner;

    [Header("Heated Potions")]
    [Space(7)]
    public bool isRedChemicalMade = false;
    public bool isOrangeChemicalMade = false;

    public GameObject redChemicalPlaceHolder;
    public GameObject orangeChemicalPlaceHolder;

    public GameObject redChemicalSpawner;
    public GameObject orangeChemicalSpawner;

    public void Awake()
    {
         pinkChemicalSpawner.SetActive(false);
         blueChemicalSpawner.SetActive(false);
         greenChemicalSpawner.SetActive(false);
         purpleChemicalSpawner.SetActive(false);
         blackChemicalSpawner.SetActive(false);

        redChemicalSpawner.SetActive(false);
        orangeChemicalSpawner.SetActive(false);
    }

    public void PotionChecker()
    {
        //red
        if (isRedChemicalMade)
        {
            if (redChemicalPlaceHolder != null)
            { 
                Destroy(redChemicalPlaceHolder);
                redChemicalSpawner.SetActive(true);
                return;
            }            
        }

        //orange
        if (isOrangeChemicalMade)
        {
            if (orangeChemicalPlaceHolder != null)
            {
                Destroy(orangeChemicalPlaceHolder);
                orangeChemicalSpawner.SetActive(true);
                return;
            }
        }

        //green
        if (isGreenChemicalMade)
        {
            if (greenChemicalPlaceHolder != null)
            {
                Destroy(greenChemicalPlaceHolder);
                greenChemicalSpawner.SetActive(true);
                return;
            }
        }

        //blue
        if (isBlueChemicalMade)
        {
            if (blueChemicalPlaceHolder != null)
            {
                Destroy(blueChemicalPlaceHolder);
                blueChemicalSpawner.SetActive(true);
                return;
            }
        }

        //purple
        if (isPurpleChemicalMade)
        {
            if (purpleChemicalPlaceHolder != null)
            {
                Destroy(purpleChemicalPlaceHolder);
                purpleChemicalSpawner.SetActive(true);
                return;
            }
        }

        //pink
        if (isPinkChemicalMade)
        {
            if (pinkChemicalPlaceHolder != null)
            {
                Destroy(pinkChemicalPlaceHolder);
                pinkChemicalSpawner.SetActive(true);
                return;
            }
        }

        if (isBlackChemicalMade)
        {
            if (blackChemicalPlaceHolder != null)
            {
                Destroy(blackChemicalPlaceHolder);
                blackChemicalSpawner.SetActive(true);
                return;
            }
        }

    }
}
