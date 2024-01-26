using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FootstepSoundSwitcher : MonoBehaviour
{
    public AudioClip[] normalFootsteps;
    public AudioClip[] squeekyBoots;
    public FirstPersonController controller;
    public void StartSqueeky()
    {
        controller.m_FootstepSounds = squeekyBoots;
    }
    public void StopSqueeky()
    {
        controller.m_FootstepSounds = normalFootsteps;
    }
}
