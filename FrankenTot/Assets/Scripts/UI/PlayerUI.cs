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
    public GameObject HoldingUI;

    [SerializeField]
    public GameObject InspectingUI;

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




    // Start is called before the first frame update
    void Start()
    {
        InspectingUI.SetActive(false);
        HoldingUI.SetActive(false);
        UIPrompt.SetActive(false);

        
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }



    public void UpdateUItoE()
    {
        UIPromptImage.sprite = EKey;
        UIPrompt.SetActive(true);
    }

    public void UpdateUItoLMB()
    {
        UIPromptImage.sprite = LMB;
        UIPrompt.SetActive(true);
    }

    public void UpdateUItoRMB()
    {
        UIPromptImage.sprite = RMB;
        UIPrompt.SetActive(true);
    }

    public void UpdateUItoEmpty()
    {
        UIPrompt.SetActive(false);
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
}
