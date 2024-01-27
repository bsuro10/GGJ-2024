using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollectible : Collectible
{
    [SerializeField] private GameObject shelf;

    public override void PickUp()
    {
        if (shelf != null)
            shelf.layer = LayerMask.NameToLayer("Interactable");
        Narrator.Instance.setTarget(Narrator.Instance.player);
        base.PickUp();
    }
}
