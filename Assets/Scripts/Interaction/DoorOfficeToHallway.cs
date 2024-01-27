using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorOfficeToHallway : Interactable
{
    public override void Interact()
    {
        GetComponentInParent<Door>().BashOpenDoor();
        var footswitcher = FindFirstObjectByType<FirstPersonController>().GetComponent<FootstepSoundSwitcher>();
        footswitcher.StopForGood();
    }

    public override string GetText()
    {
        return "Press 'E' to Let yourself in";
    }
}
