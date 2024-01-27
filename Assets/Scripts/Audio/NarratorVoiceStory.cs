using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorVoiceStory : MonoBehaviour
{
    public AudioSource source;
    public void Play(float delay)
    {
        StartCoroutine(PlayWithDelay(delay));
    }

    public void Pause()
    {
        source.Pause();
        print("Paused voice story");
    }

    public void Stop()
    {
        source.Stop();
        print("Stopped voice story");
    }

    IEnumerator PlayWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        source.Play();
        print("Start voice story");
    }
}
