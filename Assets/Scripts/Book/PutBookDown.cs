using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class PutBookDown : MonoBehaviour
{

    [SerializeField] private Animator bookAnimator;
    [SerializeField] private UnityEvent afterCallback;
    [SerializeField] private AudioSource bookTableAudioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            bookAnimator.SetTrigger("PlaceDown");
            AudioManager.Instance.PlaySound("close_book");
            bookTableAudioSource.PlayDelayed(2.5f);
            afterCallback.Invoke();
            this.enabled = false;
        }
    }
}
