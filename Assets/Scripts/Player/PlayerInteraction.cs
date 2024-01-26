using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Camera cam;
    [SerializeField] private InteractPrompt interactPrompt;

    private void Start()
    {
        interactPrompt.gameObject.SetActive(false);
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
                interactPrompt.gameObject.SetActive(true);
                interactPrompt.text.text = interactable.GetText();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                interactPrompt.gameObject.SetActive(false);
            }
        }
        else
        {
            interactPrompt.gameObject.SetActive(false);
        }
    }
}