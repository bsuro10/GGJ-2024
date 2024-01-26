using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FootstepSoundSwitcher : MonoBehaviour
{
    public AudioClip[] normalFootsteps;
    public AudioClip[] squeekyBoots;
    public FirstPersonController controller;

    private bool squeeky = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!squeeky) StartSqueeky();
            else StopSqueeky();
        }
    }
    public void StartSqueeky()
    {
        controller.m_FootstepSounds = squeekyBoots;
        squeeky = true;
    }

    public void StopSqueeky()
    {
        controller.m_FootstepSounds = normalFootsteps;
        squeeky = false;
    }
}
