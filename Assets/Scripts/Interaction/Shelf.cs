using System;
using System.Collections;
using UnityEngine;

public class Shelf : Interactable
{
    [SerializeField] private Item bookItemRef;
    [SerializeField] private GameObject bookItemHidden;
    [SerializeField] private string voiceline;
    [SerializeField] private float delay;

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
            StartCoroutine(InvokeVoicelineAfterDelay());
        } 
        else if (canPickBookBack && currentItem.name.Equals(bookItemRef.name))
        {
            wasBookPickedUp = true;
            InventoryManager.Instance.Add(currentItem);
            currentItem = null;
            bookItemHidden.SetActive(false);
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

    IEnumerator InvokeVoicelineAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        AudioManager.Instance.PlayVoiceline(voiceline);
        this.canPickBookBack = true;
    }

}
