using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics.Tracing;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField]
    public GameObject GameUI;

    [SerializeField]
    public GameObject PauseMenuUI;

    [SerializeField]
    public GameObject interactingUI;

    [SerializeField]
    public GameObject HoldingUI;

    [SerializeField]
    public GameObject InspectingUI;


    [Header("Flashlight UI Images")]
    [Space(7)]
    [SerializeField]
    public GameObject FlashLightUI;

    [SerializeField]
    public bool hasFlashlight = false;

    [Header("INTERACT UI Images")]
    [Space(7)]
    [SerializeField]
    public GameObject UIPrompt;
    [SerializeField]
    public Image UIPromptImage;
    [SerializeField]
    public Sprite EKey;
    [SerializeField]
    public Sprite RMB;
    [SerializeField]
    public Sprite LMB;

    private Vector3 MouseButtonsScale = new Vector3(1.3f, 1.3f, 1.3f);
    private Vector3 EButtonScale = new Vector3(2.5f, 2.5f, 2.5f);

    [Header("FrankenTot State UI Images")]
    [Space(7)]
    [SerializeField]
    public GameObject frankentotState;
    [SerializeField]
    public Image frankentotStateImage;
    [SerializeField]
    public Sprite Crouching;
    [SerializeField]
    public Sprite Standing;
    //[SerializeField]
   // public Sprite Sprinting;



    // Start is called before the first frame update
    void Start()
    {
        InspectingUI.SetActive(false);
        HoldingUI.SetActive(false);
        UIPrompt.SetActive(false);
        frankentotState.SetActive(true);
        FlashLightUI.SetActive(false);
        PauseMenuUI.SetActive(false);

        
    }

    public void Update()
    {
        if (hasFlashlight)
        {
            FlashLightUI.SetActive(true);
        }
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }



    //control which UI image is shown
    public void UpdateUItoE()
    {
        UIPromptImage.sprite = EKey;
        UIPromptImage.transform.localScale = EButtonScale;
        UIPrompt.SetActive(true);
    }

    public void UpdateUItoLMB()
    {
        UIPromptImage.sprite = LMB;
        UIPromptImage.transform.localScale = MouseButtonsScale;
        UIPrompt.SetActive(true);
    }

    public void UpdateUItoRMB()
    {
        UIPromptImage.sprite = RMB;
        UIPromptImage.transform.localScale = MouseButtonsScale;
        UIPrompt.SetActive(true);
    }

    public void UpdateUItoEmpty()
    {
        UIPrompt.SetActive(false);
    }




    //States of FtotImage
    public void UpdateFStateCrouch()
    {
        frankentotStateImage.sprite = Crouching;
    }
    public void UpdateFStateStand()
    {
        frankentotStateImage.sprite = Standing;
    }



    //Called when a player Enters Inspect Mode
    public void EnterInspectUI()
    {
        InspectingUI.SetActive(true);
       

        HoldingUI.SetActive(false);


        
    }

    //Called when a Player Exits Inspect Mode
    public void ExitInspectUI()
    {
        InspectingUI.SetActive(false);

        HoldingUI.SetActive(true);

        
    }

    //Called when a player Picks up an object
    public void PickUpObjectUI()
    {
        HoldingUI.SetActive(true);
    }

    //Called when a player drops an object
    public void PutDownObjectUI() 
    {
        HoldingUI.SetActive(false);
    }

    public void PauseGame()
    {
        GameUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void UnpauseGame()
    {
        GameUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

}
