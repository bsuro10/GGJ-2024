using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutLever : Interactable
{

    [SerializeField] private Item leverItemRef;
    [SerializeField] private GameObject lever;

    public override void Interact()
    {
        if (InventoryManager.Instance.isExist(leverItemRef))
        {
            lever.SetActive(true);
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    public override string GetText()
    {
        return "Place Lever";
    }

}
