using UnityEngine;
using UnityEngine.Events;

public class Collectible : Interactable
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + amount + " " + item.name);
        bool wasPickedUp = InventoryManager.Instance.Add(item, amount);

        if (wasPickedUp)
            Destroy(gameObject);
    }

}