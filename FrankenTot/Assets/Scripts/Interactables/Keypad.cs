using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private KeypadController keypadController;
    protected override void Interact()
    {
     if (gameObject.name == "ENTER")
        {
            //if the input matches the password
            if (keypadController.input == keypadController.password)
            {
                keypadController.MoveWall();
            }
        }
     else if (gameObject.name == "CANCEL")
        {
            keypadController.input = "";
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
