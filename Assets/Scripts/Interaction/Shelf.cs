using System;
using System.Collections;
using UnityEngine;

public class Shelf : Interactable
{
    [SerializeField] private Item bookItemRef;
    [SerializeField] private GameObject bookItemHidden;
    [SerializeField] private float delay;
    [SerializeField] private GameObject window;

    private Item currentItem;
    private bool canPickBookBack = false;
    private bool wasBookPickedUp = false;

    private void Start()
    {
        bookItemHidden.SetActive(false);
    }

    public override void Interact()
    {
        if (wasBookPickedUp)
            return;

        if (InventoryManager.Instance.isExist(bookItemRef))
        {
            currentItem = bookItemRef;
            bookItemHidden.SetActive(true);
            InventoryManager.Instance.Remove(currentItem);
            AudioManager.Instance.PlaySound("putdown");
            Narrator.Instance.setTarget(bookItemHidden.transform);
            StartCoroutine(InvokeDelayOnPickUpBook());
        } 
        else if (canPickBookBack && currentItem.name.Equals(bookItemRef.name))
        {
            wasBookPickedUp = true;
            InventoryManager.Instance.Add(currentItem);
            currentItem = null;
            bookItemHidden.SetActive(false);
            AudioManager.Instance.PlaySound("pickup");
            Narrator.Instance.setTarget(Narrator.Instance.player);
            Narrator.Instance.pauseForDelay(1);
            this.enabled = false;
        }
    }

    public override string GetText()
    {
        if (!canPickBookBack && currentItem && currentItem.name.Equals(bookItemRef.name) || wasBookPickedUp)
        {
            return "";
        }
        return base.GetText();
    }

    IEnumerator InvokeDelayOnPickUpBook()
    {
        yield return new WaitForSeconds(delay);
        this.canPickBookBack = true;
        this.window.SetActive(true);
    }

}
