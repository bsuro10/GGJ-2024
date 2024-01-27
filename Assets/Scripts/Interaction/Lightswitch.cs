using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    public override void Interact()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public override string GetText()
    {
        return "Press 'E' to turn the lights on.";
    }
}
