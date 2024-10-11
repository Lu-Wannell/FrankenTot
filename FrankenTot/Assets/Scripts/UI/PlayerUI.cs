using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField]
    public GameObject HoldingUI;

    [SerializeField]
    public GameObject InspectingUI;
    

    // Start is called before the first frame update
    void Start()
    {
        InspectingUI.SetActive(false);
        HoldingUI.SetActive(false);
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
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
