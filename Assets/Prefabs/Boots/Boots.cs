using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boots : Interactable
{
    public GameObject cameraObj;
    public override void Interact()
    {
        GetComponentInParent<FootstepSoundSwitcher>().StopSqueeky();
        gameObject.SetActive(false);
        cameraObj.transform.localPosition = 
            new Vector3(cameraObj.transform.localPosition.x, 0.42f, cameraObj.transform.localPosition.z);
    }

    public override string GetText()
    {
        return "Press 'E' to take off boots";
    }
}
