using UnityEngine;
using UnityEngine.Events;

public class Collectible : Interactable
{
    [SerializeField] public Item item;
    [SerializeField] private int amount = 1;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public override string GetText()
    {
        return "Press 'E' to pick up " + transform.name;
    }

    public virtual void PickUp()
    {
        Debug.Log("Picking up " + amount + " " + item.name);
        bool wasPickedUp = InventoryManager.Instance.Add(item, amount);
        AudioManager.Instance.PlaySound("pickup");
        if (wasPickedUp)
            Destroy(gameObject);
    }

}