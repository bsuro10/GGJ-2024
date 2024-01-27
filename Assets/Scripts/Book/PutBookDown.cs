using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class PutBookDown : MonoBehaviour
{
    public Book1 book1;
    [SerializeField] private Animator bookAnimator;
    [SerializeField] private UnityEvent afterCallback;
    [SerializeField] private NarratorVoiceStory narratorVoice;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            bookAnimator.SetTrigger("PlaceDown");
            AudioManager.Instance.PlaySound("close_book");
            //StartCoroutine(book1.KeepReading());
            afterCallback.Invoke();
            this.enabled = false;
        }
    }
}
