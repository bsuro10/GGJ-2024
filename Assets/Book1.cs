using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book1 : MonoBehaviour
{
    public AudioClip keepReading;
    public AudioClip[] storylines;
    public AudioSource source;
    private int storyIndex = -1;
    private bool isPaused = false;

    private void Start()
    {
        StartCoroutine(PlayStoryline());
    }

    public IEnumerator PlayStoryline()
    {
        while (true)
        {
            yield return null;
            if (!source.isPlaying && !isPaused)
            {
                storyIndex++;
                storyIndex %= storylines.Length;
                source.clip = storylines[storyIndex];
                source.Play();
                print("hello");
            }
        }
    }

    public IEnumerator KeepReading()
    {
        isPaused = true;
        yield return new WaitForSeconds(2f);
        source.clip = keepReading;
        isPaused = false; //plays in playstoryline
    }
}
