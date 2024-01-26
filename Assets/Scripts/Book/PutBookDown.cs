using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class PutBookDown : MonoBehaviour
{

    [SerializeField] private UnityEvent afterCallback;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("PlaceDown");
            afterCallback.Invoke();
            this.enabled = false;
        }
    }
}
