using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject interactPrompt;

    private void Start()
    {
        interactPrompt.SetActive(false);
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                interactPrompt.SetActive(false);
            }
        }
        else
        {
            interactPrompt.SetActive(false);
        }
    }
}