using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloche : Interactable
{
    public override void Interact()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<Animator>().SetTrigger("open");
    }

}
