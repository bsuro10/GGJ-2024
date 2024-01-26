using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] sounds;
    private Dictionary<string, Sound> soundsDict = new();

    public Voiceline[] voicelines;
    private Dictionary<string, Voiceline> voicelinesDict = new();
    private AudioSource[] voicelineAudioSource = new AudioSource[2];
    private int currentVoicelineSource = 0;

    public AudioMixerGroup masterGroup;
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;
    public AudioMixerGroup dialogueGroup;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        foreach(Sound sound in sounds)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            float volume = sound.volume;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = sfxGroup;
            sound.source = audioSource;
            soundsDict[sound.name] = sound;
        }

        voicelineAudioSource[0] = gameObject.AddComponent<AudioSource>();
        voicelineAudioSource[1] = gameObject.AddComponent<AudioSource>();
        voicelineAudioSource[0].outputAudioMixerGroup = dialogueGroup;
        voicelineAudioSource[1].outputAudioMixerGroup = dialogueGroup;

        foreach(Voiceline voiceline in voicelines)
        {
            voicelinesDict[voiceline.name] = voiceline;
        }
    }

    public void PlaySound(string name)
    {
        Sound sound = soundsDict[name];
        sound.source.PlayOneShot(sound.GetClip());
    }

    public void PlayVoiceline(string name, float delay = 0f, Vector3 position = default)
    {
        StartCoroutine(PlayVoicelineCR(name, delay, position));
    }

    IEnumerator PlayVoicelineCR(string name, float delay = 0f, Vector3 position = default)
    {
        if (delay > 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        AudioClip clip = voicelinesDict[name].GetClip();
        AudioSource current = voicelineAudioSource[currentVoicelineSource];
        AudioSource next = voicelineAudioSource[currentVoicelineSource ^ 1];
        if (current.isPlaying)
        {
            //Fade out current quickly so no clicks
            StartCoroutine(FadeOut(current));
        }

        next.clip = clip;
        next.volume = 1f;
        next.Play();
        currentVoicelineSource ^= 1;
    }

    IEnumerator FadeOut(AudioSource source, float duration = 0.15f)
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

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    [System.Serializable]
    public class Sound
    {
        public string name;
        [HideInInspector] public AudioSource source;
        public AudioClip[] clips;
        private int currentClipIndex = -1;
        [Range(0.0001f, 1f)] public float volume;

        public AudioClip GetClip()
        {
            if(currentClipIndex + 1 < clips.Length)
            {
                currentClipIndex++;
            }
            else
            {
                currentClipIndex = 0;
            }

            return clips[currentClipIndex];
        }
    }

    [System.Serializable]
    public class Voiceline
    {
        public enum VoicelineMode
        {
            Single,
            Cycle,
            Linear,
            Random,
        }

        public string name;
        public AudioClip[] clips;
        public VoicelineMode mode;
        private int currentClipIndex = -1;

        public AudioClip GetClip()
        {
            switch (mode) 
            {
                case VoicelineMode.Single:
                    currentClipIndex = 0;
                    break;
                case VoicelineMode.Cycle:
                    currentClipIndex++;
                    currentClipIndex %= clips.Length;
                    break;
                case VoicelineMode.Linear:
                    if (currentClipIndex < clips.Length) 
                    {
                        currentClipIndex++;
                    }
                    break;
                case VoicelineMode.Random:
                    int randomIndex = -1;
                    do
                    {
                        randomIndex = Random.Range(0, clips.Length);
                    } while (randomIndex == currentClipIndex);

                    currentClipIndex = randomIndex;
                    break;
            }

            return clips[currentClipIndex];
        }
    }
}

