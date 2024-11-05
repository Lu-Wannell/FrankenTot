using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private KeypadController keypadController;

    [SerializeField]
    private GameObject keypadLight;
    [SerializeField]
    private Light mylight;

    [SerializeField]
    private Light mylight2;

    [SerializeField]
    private AudioSource correctBuzzerAudio;

    public void Start()
    {
        keypadLight.SetActive(false);
    }
    protected override void Interact()
    {
     if (gameObject.name == "ENTER")
        {
            //if the input matches the password
            if (keypadController.input == keypadController.password)
            {
                keypadController.MoveWall();
                keypadLight.SetActive(true);
                correctBuzzerAudio.Play();
                mylight.color = Color.green;
                mylight2.color = Color.green;

            }
            else
            {
                keypadLight.SetActive(true);
                mylight.color = Color.red;
                mylight2.color = Color.red;
            }

        }
     else if (gameObject.name == "CANCEL")
        {
            keypadController.input = "";
            keypadLight.SetActive(false);
        }
        else
        {
            if (keypadController.input.Length < 6)
            {
                keypadController.input = keypadController.input + gameObject.name;
            }
        }
     keypadController.keypadText.text = keypadController.input;
    }
}
