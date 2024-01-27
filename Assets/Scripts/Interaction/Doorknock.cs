using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorknock : Interactable
{
    [SerializeField] private Door door;
    [SerializeField] private Doorbell doorbell;
    public override void Interact()
    {
        AudioManager.Instance.PlaySound("doorbell");
        GetComponent<SphereCollider>().enabled = false;
        doorbell.GetComponent<SphereCollider>().enabled = false;
        door.Invoke(nameof(door.OpenSlightly), 4f);
    }

    public override string GetText()
    {
        return "Press 'E' to politely knock on the door";
    }
}
