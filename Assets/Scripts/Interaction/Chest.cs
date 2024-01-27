using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    [SerializeField] private Animator animator;

    public override void Interact()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        animator.SetBool("isOpen", true);
    }

    public override string GetText()
    {
        return "Press 'E' to open.";
    }
}
