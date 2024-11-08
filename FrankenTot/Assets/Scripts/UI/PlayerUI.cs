using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    FirstPersonControls firstPersonControls;

    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField]
    public GameObject GameUI;

    [SerializeField]
    public GameObject PauseMenuUI;

    [SerializeField]
    public GameObject PauseUI;

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
    [SerializeField]
    public Sprite Walking;
    [SerializeField]
    public Sprite Sprinting;

    [Header("End Game UI")]
    [Space(7)]
    [SerializeField]
    public bool isEndScene = false;

    public static PlayerUI instance;

    void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

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
        if (isEndScene)
        { return; }

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

    public void UpdateFStateWalk()
    {
        frankentotStateImage.sprite = Walking;
    }

    public void UpdateFStateSprint()
    {
        frankentotStateImage.sprite = Sprinting;
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
        if(!isEndScene) 
        {
            GameUI.SetActive(false);
            PauseMenuUI.SetActive(true);           
        }
        else
        {
            PauseMenuUI.SetActive(true);
            PauseUI.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UnpauseGame()
    {
        if (!isEndScene)
        {
            
            GameUI.SetActive(true);
            PauseMenuUI.SetActive(false);
        }
        else
        {
            PauseMenuUI.SetActive(false);
            PauseUI.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EndScreenActive()
    {
        InspectingUI.SetActive(false);
        HoldingUI.SetActive(false);
        frankentotState.SetActive(false);
        FlashLightUI.SetActive(false);
        interactingUI.SetActive(false);
        firstPersonControls.isEndScreen = true;
    }

}
