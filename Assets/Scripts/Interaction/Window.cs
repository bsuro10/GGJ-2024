using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
{
    [SerializeField] private Transform bookThrowingTransform;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject cloneBookOnTable;
    [SerializeField] private Item bookItemRef;
    [SerializeField] private GameObject fireplace;

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
            cloneBookOnTable.SetActive(true);
            fireplace.SetActive(true);
            AudioManager.Instance.PlayVoiceline("do_that_again", 2f);
        }
    }

    public override string GetText()
    {
        if (wasInteracted) return "";
        return base.GetText();
    }
}
