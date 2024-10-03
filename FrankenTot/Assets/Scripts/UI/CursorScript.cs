using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    private bool cursorLocked;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void Start()
    {
       Cursor.visible = true;
       
    }


   
    

    
}
