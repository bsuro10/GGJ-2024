using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Animator animator;
    private bool isOpen = false;

    public override void Interact()
    {
        if (isOpen) return;

        isOpen = true;
        animator.SetBool("isOpen", true);
    }

    public override string GetText()
    {
        if(!isOpen) return "Press 'E' to open.";
        return "";
    }
}
