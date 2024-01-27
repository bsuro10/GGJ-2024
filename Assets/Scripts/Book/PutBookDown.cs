using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class PutBookDown : MonoBehaviour
{

    [SerializeField] private Animator bookAnimator;
    [SerializeField] private UnityEvent afterCallback;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            bookAnimator.SetTrigger("PlaceDown");
            afterCallback.Invoke();
            this.enabled = false;
        }
    }
}
