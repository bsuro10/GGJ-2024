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
        if(squeekySteps == 5 && squeekSequence == 1)
        {
            AudioManager.Instance.PlayVoiceline("where'd_you_get_those");
        }
        else if (squeekySteps == 12 && squeekSequence == 1)
        {
            AudioManager.Instance.PlayVoiceline("not_gonna_take_those_boots_off");
        }
        else if (squeekySteps == 4 && squeekSequence == 2)
        {
            AudioManager.Instance.PlayVoiceline("forgot_to_stop");
            StopSqueeky();
        }
    }
}
