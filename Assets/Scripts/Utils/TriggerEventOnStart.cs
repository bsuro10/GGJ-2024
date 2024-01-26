using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventOnStart : MonoBehaviour
{
    [SerializeField] private UnityEvent callback;

    void Start()
    {
        callback.Invoke();
    }

}
