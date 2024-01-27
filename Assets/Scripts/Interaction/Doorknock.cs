using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorknock : Interactable
{
    [SerializeField] private Door door;
    [SerializeField] private Doorbell doorbell;
    public override void Interact()
    {
        // ring doorbell loudly
        door.Invoke(nameof(door.OpenSlightly), 4f);
        //AudioManager.Instance.PlaySound("loud_doorbell");

        GetComponent<SphereCollider>().enabled = false;
        doorbell.GetComponent<SphereCollider>().enabled = false;
    }

    public override string GetText()
    {
        return "Press 'E' to politely knock on the door";
    }
}
