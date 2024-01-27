using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorVoiceStory : MonoBehaviour
{
    public AudioSource headSource;
    public AudioSource sourceRef;
    public AudioClip[] storylines;
    private int storyIndex = -1;
    private bool readingStory = true;
    private bool isPaused = false;
    private void Start()
    {
        sourceRef = headSource;
        StartCoroutine(PlayStoryline());
    }

    public IEnumerator PlayStoryline()
    {
        while (readingStory)
        {
            yield return null;
            if (!sourceRef.isPlaying && !isPaused)
            {
                storyIndex++;
                storyIndex %= storylines.Length;
                sourceRef.clip = storylines[storyIndex];
                sourceRef.Play();
            }
        }
    }
    public void UnPause(float delay)
    {
        StartCoroutine(UnPauseWithDelay(delay));
    }

    public void Pause()
    {
        sourceRef.Stop();
        isPaused = true;
        print("Paused voice story");
    }

    public void SwitchSources(AudioSource newRef)
    {
        sourceRef.Stop();
        newRef.clip = sourceRef.clip;
        newRef.time = sourceRef.time;
        sourceRef = newRef;
    }

    public void Stop()
    {
        sourceRef.Stop();
        print("Stopped voice story");
    }

    public void PlayDelayed(AudioClip clip, float delay)
    {
        StartCoroutine(PlayWithDelay(clip, delay));
    } 

    IEnumerator PlayWithDelay(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        sourceRef.clip = clip;
        isPaused = true;
        sourceRef.Play();
        sourceRef.Pause();
        print("Start voice story");
        isPaused = false;
    }

    IEnumerator UnPauseWithDelay(float delay)
    {
        storyIndex++;
        storyIndex %= storylines.Length;
        sourceRef.clip = storylines[storyIndex];
        yield return new WaitForSeconds(delay);
        sourceRef.Play();
        print("Start voice story");
        isPaused = false;
    }
}
