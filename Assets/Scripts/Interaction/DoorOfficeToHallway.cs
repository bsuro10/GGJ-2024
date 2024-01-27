using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOfficeToHallway : Interactable
{
    public override void Interact()
    {
        GetComponentInParent<Door>().BashOpenDoor();
    }

    public override string GetText()
    {
        return "Press 'E' to Let yourself in";
    }
}
