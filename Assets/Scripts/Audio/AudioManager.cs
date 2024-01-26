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
    private AudioSource voicelineAudioSource;

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

        voicelineAudioSource = gameObject.AddComponent<AudioSource>();
        voicelineAudioSource.outputAudioMixerGroup = dialogueGroup;
        voicelineAudioSource.clip = voicelines[0].GetClip();

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

    public void PlayVoiceline(string name, Vector3 position = default)
    {
        AudioClip clip = voicelinesDict[name].GetClip();
        if (voicelineAudioSource.isPlaying) 
        {
            //Fade out quickly so no clicks
        }

        voicelineAudioSource.clip = clip;
        voicelineAudioSource.Play();
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

