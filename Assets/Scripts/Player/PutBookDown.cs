using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutBookDown : MonoBehaviour
{

    [SerializeField] private GameObject book;
    [SerializeField] private UnityEvent afterCallback;

    private Animator animator;

    void Start()
    {
        animator = book.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("PlaceDown");
            afterCallback.Invoke();
            Destroy(this.gameObject);
        }
    }
}
