using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorForcePosition;

    [ContextMenu("Open")]
    public void Open()
    {
        animator.SetBool("isOpen", true);
        AudioManager.Instance.PlaySound("open_door");
    }


    [ContextMenu("Open slightly")]
    public void OpenSlightly()
    {
        animator.SetTrigger("openSlightly");
        door.AddComponent<DoorOfficeToHallway>();
        //AudioManager.Instance.PlaySound("open_door_slightly");
    }

    [ContextMenu("Bash open door")]
    public void BashOpenDoor()
    {
        print("Bashing door open");
        //AudioManager.Instance.PlaySound("bash_open_door");
    }

    [ContextMenu("Close")]
    public void Close()
    {
        animator.SetBool("isOpen", false);
        AudioManager.Instance.PlaySound("close_door");
    }
}
