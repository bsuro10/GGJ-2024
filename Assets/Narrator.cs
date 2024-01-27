using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] storyLines;
    [SerializeField] private AudioClip[] remarks;
    [SerializeField] int currStory = 0;
    [SerializeField] int currRemark = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) playStory();
    }

    void playStory()
    {
        if (currStory == storyLines.Length) currStory = 0;

        source.clip = storyLines[currStory];
        source.Play();
        currStory++;
    }

    void playRemark(float delay)
    {
        if (currRemark == remarks.Length) currRemark = 0;

        source.clip = remarks[currRemark];
        source.PlayDelayed(delay);
        currRemark++;
    }

    public void pauseForDelay(float delay)
    {
        source.Stop();
        playRemark(delay);
    }
}
