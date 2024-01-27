using System;
using System.Collections;
using UnityEngine;

public class Shelf : Interactable
{
    [SerializeField] private Item bookItemRef;
    [SerializeField] private GameObject bookItemHidden;
    private AudioSource bookAudioSource;
    [SerializeField] private string voiceline;
    [SerializeField] private float delay;
    [SerializeField] private GameObject window;
    [SerializeField] private NarratorVoiceStory narratorVoiceStory;

    private Item currentItem;
    private bool canPickBookBack = false;
    private bool wasBookPickedUp = false;

    private void Start()
    {
        bookItemHidden.SetActive(false);
        bookAudioSource = bookItemHidden.GetComponent<AudioSource>();
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
            bookAudioSource.Play();
            print("started closet voice story");
            narratorVoiceStory.Stop();
            bookAudioSource.timeSamples = narratorVoiceStory.source.timeSamples;
            StartCoroutine(InvokeDelayOnPickUpBook());
        } 
        else if (canPickBookBack && currentItem.name.Equals(bookItemRef.name))
        {
            wasBookPickedUp = true;
            InventoryManager.Instance.Add(currentItem);
            currentItem = null;
            bookItemHidden.SetActive(false);
            bookAudioSource.Stop();
            print("stopped closet voice story");
            AudioManager.Instance.PlayVoiceline("finally");
            narratorVoiceStory.Play(3f);
            narratorVoiceStory.source.timeSamples = bookAudioSource.timeSamples;
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
