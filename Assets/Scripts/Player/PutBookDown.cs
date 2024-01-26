using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PutBookDown : MonoBehaviour
{

    [SerializeField] private GameObject book;
    [SerializeField] private UnityEvent afterEventCallback;

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
            afterEventCallback.Invoke();
            Destroy(this.gameObject);
        }
    }
}
