using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{
    [SerializeField]
    private GameObject bookShelf;
    private bool bookShelfOpen;

    protected override void Interact() // interacting with book moves a bookshelf
    {
        bookShelfOpen = !bookShelfOpen;
        bookShelf.GetComponent<Animator>().SetBool("isOpen", bookShelfOpen);
    }
}
