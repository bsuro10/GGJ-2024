using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public static Narrator Instance;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] storyLines;
    [SerializeField] private AudioClip[] remarks;
    [SerializeField] private Transform targetTransform;
    [SerializeField] public Transform player;
    [SerializeField] int currStory = 0;
    [SerializeField] int currRemark = 0;
    private bool isStopped = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

 
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(targetTransform != null)
        {
            this.transform.position = targetTransform.position;
        }

        if (!source.isPlaying && !isStopped) playStory();
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

    public void setTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    public void stopAudio()
    {
        StartCoroutine(delayStopAudio());
        
    }

    IEnumerator FadeOut(float duration = 0.15f)
    {
        float startVolume = source.volume;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0.0f, timer / duration);
            yield return null; // Wait for the next frame
        }

        source.Stop();
        source.volume = 1.0f;
    }

    private IEnumerator delayStopAudio()
    {
        yield return new WaitForSeconds(1f);
        isStopped = true;
        StartCoroutine(FadeOut());
    }
}
