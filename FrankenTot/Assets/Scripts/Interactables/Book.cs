using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{
    [SerializeField]
    private GameObject bookShelf;
    private bool bookShelfOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        bookShelfOpen = !bookShelfOpen;
        bookShelf.GetComponent<Animator>().SetBool("isOpen", bookShelfOpen);
    }
}
