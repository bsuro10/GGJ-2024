using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fireplace : Interactable
{
    [SerializeField] private Transform bookThrowingTransform;
    [SerializeField] private Item bookItemRef;
    [SerializeField] private GameObject book;
    [SerializeField] private UnityEvent afterCallback;
    [SerializeField] private float afterCallbackDelay;

    [SerializeField] private AudioSource bookFireAudio;

    private bool wasInteracted = false;

    public override void Interact()
    {
        if (wasInteracted)
            return;

        if (InventoryManager.Instance.isExist(bookItemRef))
        {
            wasInteracted = true;
            InventoryManager.Instance.Remove(bookItemRef);
            book.SetActive(true);
            book.transform.position = bookThrowingTransform.position;
            book.GetComponent<Animator>().SetTrigger("Throw");
            bookFireAudio.PlayDelayed(0.2f);
            StartCoroutine(InvokeAfterDelay());
        }
    }

    public override string GetText()
    {
        if (wasInteracted) return "";
        return base.GetText();
    }

    IEnumerator InvokeAfterDelay()
    {
        yield return new WaitForSeconds(afterCallbackDelay);
        afterCallback.Invoke();
    }

}
