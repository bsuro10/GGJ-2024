using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : Interactable
{
    [SerializeField] private Door door;
    [SerializeField] private Doorknock doorknock;
    public override void Interact()
    {
        // ring doorbell small or door kncok
        door.Invoke(nameof(door.OpenSlightly), 4.0f);
        AudioManager.Instance.PlaySound("doorbell");
        GetComponent<SphereCollider>().enabled = false;
        doorknock.GetComponent<SphereCollider>().enabled = false;
    }

    public override string GetText()
    {
        return "Press 'E' to ring the doorbell";
    }
}
