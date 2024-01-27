using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : Interactable
{
    [SerializeField] private UnityEvent callback;

    public override void Interact()
    {
        GetComponent<Animator>().SetBool("LeverDown", true);
        gameObject.layer = LayerMask.NameToLayer("Default");
        AudioManager.Instance.PlayVoiceline("ending", 1f);
        StartCoroutine(Callback());
    }

    IEnumerator Callback()
    {
        yield return new WaitForSeconds(1.0f);
        callback.Invoke();
    }

    public override string GetText()
    {
        return "SHUT DOWN the narrator";
    }

}
