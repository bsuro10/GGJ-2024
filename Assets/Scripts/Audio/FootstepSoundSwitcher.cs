using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FootstepSoundSwitcher : MonoBehaviour
{
    public AudioClip[] normalFootsteps;
    public AudioClip[] squeekyBoots;
    public FirstPersonController controller;
    public bool squeeky;
    public int squeekySteps = 0;

    public int squeekSequence = 0;
    public void StartSqueeky()
    {
        controller.m_FootstepSounds = squeekyBoots;
        squeekSequence += 1;
        squeeky = true;
        squeekySteps = 0;
    }
    public void StopSqueeky()
    {
        controller.m_FootstepSounds = normalFootsteps;
        controller.normalFootsteps = 0;
        squeeky = false;
    }

    public void UpdateSqueekySteps()
    {
        squeekySteps += 1;
        if(squeekySteps % 5 == 0 && squeekSequence == 1)
        {
            AudioManager.Instance.PlayVoiceline("snarkey_boots_comment");
        }
        else if (squeekySteps == 4 && squeekSequence == 2)
        {
            AudioManager.Instance.PlayVoiceline("admits_boots_sounds");
            StopSqueeky();
        }
    }
}
