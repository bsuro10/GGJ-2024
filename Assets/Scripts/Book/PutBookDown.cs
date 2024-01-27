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
    [SerializeField] private NarratorVoiceStory narratorVoice;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            bookAnimator.SetTrigger("PlaceDown");
            AudioManager.Instance.PlaySound("close_book");
            narratorVoice.Pause();
            narratorVoice.PlayDelayed(bookTableAudioSource.clip, 2f);
            narratorVoice.UnPause(4.5f);
            afterCallback.Invoke();
            this.enabled = false;
        }
    }
}
