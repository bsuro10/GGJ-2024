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
        AudioManager.Instance.PlaySound("door_creek");
        door.AddComponent<DoorOfficeToHallway>();
    }

    [ContextMenu("Bash open door")]
    public void BashOpenDoor()
    {
        print("Bashing door open");
        animator.SetTrigger("bashOpen");
        door.GetComponent<BoxCollider>().enabled = false;
        AudioManager.Instance.PlaySound("door_bash");
    }

    [ContextMenu("Close")]
    public void Close()
    {
        animator.SetBool("isOpen", false);
        AudioManager.Instance.PlaySound("close_door");
    }
}
