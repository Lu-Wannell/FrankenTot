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
    public Image UIPromptImage;
    [SerializeField]
    public Sprite None;
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
        UIPromptImage.sprite = null;
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }



    public void UpdateUItoE()
    {
        UIPromptImage.sprite = EKey;
    }

    public void UpdateUItoLMB()
    {
        UIPromptImage.sprite = LMB;
    }

    public void UpdateUItoRMB()
    {
        UIPromptImage.sprite = RMB;
    }

    public void UpdateUItoEmpty()
    {
        UIPromptImage.sprite = None;
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
