using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : Interactable
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent callback;

    public override void Interact()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        animator.SetBool("isOpen", true);
    }

    public override string GetText()
    {
        return "Press 'E' to open.";
    }

    public void TriggerCallback()
    {
        callback.Invoke();
    }

}
