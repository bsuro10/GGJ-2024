using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            OnPlayerTriggerEnter();
        }
    }

    protected abstract void OnPlayerTriggerEnter();
}
