using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalMixer : Interactable
{
    [Header("Seriallized Components")]
    [Space(7)]
    [SerializeField]
    FirstPersonControls firstPersonControls;
    [SerializeField]
    PotionPuzzleController potionPuzzleController;

    [SerializeField]
    GameObject placedChemical;
    [SerializeField]
     public GameObject mixer;

    [SerializeField]
    public Vector3 chemMixerStartingPos;

    [Header("Colour SETTINGS")]
    [Space(7)]
    public Color firstChemicalColor = Color.magenta;
    public Color secondChemicalColor = Color.magenta;
    public Color thirdChemicalColor = Color.magenta;


    public Color potionColor = Color.white;
    public Color potionChangeColor = Color.white;

    public Color invisible;
    public Color white;
    public Color red;
    public Color orange;
    public Color yellow;
    public Color green;
    public Color blue;
    public Color purple;
    public Color pink;
    public Color black;

    [Header("misc SETTINGS")]
    [Space(7)]

    public float lerpSpeed = 1;

    public Material material;

    public float chemicalCount = 0;
    public float mixerFillAmount = 0.2f;

    [Header("bool SETTINGS")]
    [Space(7)]

    private bool isPinkOrBlueProcess = false;
    private bool isBlueProcess = false;
    private bool isGreenProcess = false;
    private bool isPurpleProcess = false;

    [SerializeField]
    private AudioSource chemicalMixingAudio;

    private void Start()
    {
        chemMixerStartingPos = mixer.transform.position;
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
        potionColor = material.GetColor("_TopColour");
        material.SetFloat("_Fill", mixerFillAmount);

    }

    protected override void Interact()
    {
        if(firstPersonControls.heldObject != null) 
        {
            if (firstPersonControls.heldObject.tag != "Chemical")
            {
                promptMessage = "Chemical Needed";
                return;
            }



            if (chemicalCount == 0)
            {
                ColourChecker();
                firstChemicalColor = potionChangeColor;
                
                if (firstPersonControls.heldObject.name == "White Chemical(Clone)" )
                {
                    isPinkOrBlueProcess = true;                   
                }
                else if (firstPersonControls.heldObject.name == "Yellow Chemical(Clone)")
                {
                    isGreenProcess = true;                    
                }
                else if (firstPersonControls.heldObject.name == "Blue Chemical(Clone)")
                {
                    isPurpleProcess= true;                   
                }

                promptMessage = "Place Chemical";
                ChemicalPlaced(potionColor, potionChangeColor);

            }


            else if (chemicalCount == 1)
            {
                ColourChecker();
                secondChemicalColor = potionChangeColor;
                if(firstChemicalColor ==  secondChemicalColor)
                {
                    ChemicalPlaced(potionColor, potionChangeColor);
                    return;
                }
                else
                {
                    potionChangeColor = black;
                }

                if (isPinkOrBlueProcess)
                {
                    //Pink Chemical Made
                    if(firstPersonControls.heldObject.name == "Red Chemical(Clone)")
                    {
                        potionPuzzleController.isPinkChemicalMade = true;
                        potionChangeColor = pink;
                        
                    }
                    //Further Blue Process
                    else if (firstPersonControls.heldObject.name == "Pink Chemical(Clone)")
                    {                       
                        isBlueProcess = true;
                        potionChangeColor = pink;
                    }

                    isPinkOrBlueProcess = false;
                }
                else if (isGreenProcess)
                {
                    //Green Potion Made
                    if(firstPersonControls.heldObject.name == "Blue Chemical(Clone)")
                    {
                        potionPuzzleController.isGreenChemicalMade = true;
                        potionChangeColor = green;
                    }

                    isGreenProcess = false;
                }
                else if (isPurpleProcess)
                {
                    if (firstPersonControls.heldObject.name != "Pink Chemical(Clone)")
                    {
                        isPurpleProcess = false;
                    }
                    else
                    {
                        potionChangeColor = pink;
                    }
                    
                }
                promptMessage = "Place Chemical";
                ChemicalPlaced(potionColor, potionChangeColor);
            }


            else if (chemicalCount == 2)
            {
                ColourChecker();
                thirdChemicalColor = potionChangeColor;
                if (firstChemicalColor == secondChemicalColor && secondChemicalColor == thirdChemicalColor)
                {
                    ChemicalPlaced(potionColor, potionChangeColor);
                    return;
                }
                else
                {
                    potionChangeColor = black;
                }

                if(isBlueProcess)
                {
                    if (firstPersonControls.heldObject.name == "Red Chemical(Clone)")
                    {
                        isBlueProcess = false;
                        potionPuzzleController.isBlueChemicalMade = true;
                        potionChangeColor = blue;
                    }                    
                }
                else if(isPurpleProcess)
                {
                    if (firstPersonControls.heldObject.name == "White Chemical(Clone)")
                    {                      
                        potionChangeColor = white;
                    }
                }

                promptMessage = "Place Chemical";
                ChemicalPlaced(potionColor, potionChangeColor);
            }


            else if (chemicalCount == 3)
            {
                //Colour checker
                ColourChecker();
                if (firstChemicalColor == potionChangeColor  && secondChemicalColor == thirdChemicalColor && thirdChemicalColor == firstChemicalColor)
                {
                    ChemicalPlaced(potionColor, potionChangeColor);
                    return;
                }
                else
                {
                    potionChangeColor = black;
                }               

                if (isPurpleProcess)
                {
                    if (firstPersonControls.heldObject.name == "Orange Chemical(Clone)")
                    {
                        isPurpleProcess = false;
                        potionPuzzleController.isPurpleChemicalMade = true;
                        potionChangeColor = purple;
                    }
                }
                promptMessage = "Place Chemical";
                ChemicalPlaced(potionColor, potionChangeColor);
            }

            //if Chemical count is 4 or more
            else
            {
                promptMessage = "There are too many chemicals";
            }


            potionPuzzleController.PotionChecker();

        }
    }


    private void ChemicalPlaced(Color startColour, Color changeColour)
    {
        chemicalCount++;
        placedChemical = firstPersonControls.heldObject;
        mixer.transform.position = mixer.transform.position + new Vector3(0,mixerFillAmount,0);
        chemicalMixingAudio.Play();
        //mixerFillAmount = mixerFillAmount + 0.05f;

        //material.SetFloat("_Fill", mixerFillAmount);
        material.SetColor("_TopColour", changeColour);
        //UpdateColor(startColour, changeColour);
        Destroy(firstPersonControls.heldObject);
    }


    private void ColourChecker()
    {
        if (firstPersonControls.heldObject.name == "Red Chemical(Clone)")
        {
            potionChangeColor = red;
        }
        else if (firstPersonControls.heldObject.name == "Orange Chemical(Clone)")
        {
            potionChangeColor = orange;
        }
        else if (firstPersonControls.heldObject.name == "Yellow Chemical(Clone)")
        {
            potionChangeColor = yellow;
        }
        else if (firstPersonControls.heldObject.name == "Green Chemical(Clone)")
        {
            potionChangeColor = green;
        }
        else if (firstPersonControls.heldObject.name == "Blue Chemical(Clone)")
        {
            potionChangeColor = blue;
        }
        else if (firstPersonControls.heldObject.name == "Purple Chemical(Clone)")
        {
            potionChangeColor = purple;
        }
        else if (firstPersonControls.heldObject.name == "Pink Chemical(Clone)")
        {
            potionChangeColor = pink;
        }
        else if (firstPersonControls.heldObject.name == "White Chemical(Clone)")
        {
            potionChangeColor = white;
        }
        else
        {
            potionChangeColor = black;
        }
        
    }
    

    private void UpdateColor(Color startColour, Color changeColour)
    {
       // Color lerpedColour = startColour;
       // float currentTime = 0;

       // while(lerpedColour != potionChangeColor)
      //  {
         //   lerpedColour = Color.Lerp(startColour, changeColour, Mathf.PingPong(currentTime += (Time.deltaTime * lerpSpeed / 1), 1));
            material.SetColor("_TopColour", changeColour);

       //     yield return new WaitForEndOfFrame();
       // }
        
    }
}
