using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    [SerializeField] private GameObject lightPoint;
    [SerializeField] private GameObject delayedLightPoint;
    [SerializeField] private float delay;

    public override void Interact()
    {
        lightPoint.SetActive(true);
        StartCoroutine(DelayedLightPoint());
        GetComponent<BoxCollider>().enabled = false;
    }

    public override string GetText()
    {
        return "Press 'E' to turn the lights on.";
    }


    IEnumerator DelayedLightPoint()
    {
        AudioManager.Instance.PlayVoiceline("light_switch");
        yield return new WaitForSeconds(delay);
        delayedLightPoint.SetActive(true);
    }
}
