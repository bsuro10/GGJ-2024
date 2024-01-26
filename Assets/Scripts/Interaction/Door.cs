using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [ContextMenu("Open")]
    public void Open()
    {
        animator.SetBool("isOpen", true);
        AudioManager.Instance.PlaySound("open_door");
    }

    [ContextMenu("Close")]
    public void Close()
    {
        animator.SetBool("isOpen", false);
        AudioManager.Instance.PlaySound("close_door");
    }
}
