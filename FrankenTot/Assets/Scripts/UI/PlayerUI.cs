using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject endGameUI;

    [SerializeField]
    public TextMeshProUGUI endScreenText;

    [SerializeField]
    private float fadeTime;

    [SerializeField]
    private Image fadeToBlack;

    [SerializeField]
    private bool isFading = false;
    [SerializeField]
    private float fadeNumber;

    public string EndScene;
    

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
        endGameUI.SetActive(false);

        
    }

    public void Update()
    {
        if (isEndScene)
        { return; }

        if (hasFlashlight)
        {
            FlashLightUI.SetActive(true);
        }

        if (fadeNumber == 1)
        {
            fadeNumber = 2;
            SceneManager.LoadScene(EndScene);
            firstPersonControls.isEndScreen = true;
            InitialEndText();
            StartCoroutine(Fade(1f, 0f, 3f, fadeNumber));
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
            endGameUI.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UnpauseGame()
    {
        if (!isEndScene)
        {
            Cursor.lockState = CursorLockMode.Locked;
            GameUI.SetActive(true);
            PauseMenuUI.SetActive(false);
        }
        else
        {
            PauseMenuUI.SetActive(false);
            PauseUI.SetActive(true);
            endGameUI.SetActive(true);
        }
    }

    public void EndScreenActive()
    {
        InspectingUI.SetActive(false);
        HoldingUI.SetActive(false);
        frankentotState.SetActive(false);
        FlashLightUI.SetActive(false);
        interactingUI.SetActive(false);
        StartCoroutine(Fade(0f, 1f, fadeTime, fadeNumber));
        
    }

    public void InitialEndText()
    {
        endGameUI.SetActive(true );
        endScreenText.text = "Well done, You've Completed the Game: Frankentot \r\n\r\nThe bomb timer goes off, Frankentot grabs the rat, and finds itself running up the stairs, it's mind replaying memories of it's life. The joy of being created, the initial familial love of it's father, Dr. Frankenstein...and then the abandonment. The cycle of ignoring and being forgotten. That is not love, it is not warm, but cold...";

    }

    public void SecondPartEndText()
    {
        endScreenText.text = "Frankentot stops, gingerly he runs to grab the picture of his birth and the drawing he did of his \"Family\".  With a final look at the fireplace, he tosses both in. The flames burning away what remains.\r\n\r\nFrankentot leaves to the sound of police sirens. The house explodes - and Frankentots journeys deep into the forest. \r\n\r\n\"We accept the Love, we think we deserve\" - Stephen Chbosky\r\n\r\nThe End.";
    }

    public void FinalEndScreen()
    {

    }

    private IEnumerator Fade(float start, float end, float duration, float fadeNum)
    {        
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(start, end, currentTime / duration);
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }        
        fadeNumber++;
        yield break;
    }


}
