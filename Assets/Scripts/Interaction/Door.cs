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
        AudioManager.Instance.PlaySound("open_door_slightly");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) OpenSlightly();
        else if (Input.GetKeyDown(KeyCode.V)) BashOpenDoor();
    }
    [ContextMenu("Bash open door")]
    public void BashOpenDoor()
    {
        Rigidbody doorBody = door.GetComponent<Rigidbody>();
        doorBody.isKinematic = false;
        doorBody.AddForce((transform.forward + transform.up * 0.5f).normalized * 50f, ForceMode.Impulse);
        doorBody.AddTorque(new Vector3(10f, 5f, 0f) * 500f, ForceMode.Impulse);
        //AudioManager.Instance.PlaySound("bash_open_door");
    }

    [ContextMenu("Close")]
    public void Close()
    {
        animator.SetBool("isOpen", false);
        AudioManager.Instance.PlaySound("close_door");
    }
}
