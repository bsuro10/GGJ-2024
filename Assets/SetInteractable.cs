using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractable : MonoBehaviour
{
    [SerializeField] private GameObject go;

    public void Set()
    {
        if (go != null)
            go.layer = LayerMask.NameToLayer("Interactable"); ;
    }
}
