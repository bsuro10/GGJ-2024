using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventAfterDelay : MonoBehaviour
{
    [SerializeField] private UnityEvent callback;
    [SerializeField] private int delayInSeconds;

    void Start()
    {
        StartCoroutine(InvokeAfterDelay(callback, delayInSeconds));
    }

    IEnumerator InvokeAfterDelay(UnityEvent callback, float delay)
    {
        yield return new WaitForSeconds(delay);
        callback.Invoke();
    }
}
