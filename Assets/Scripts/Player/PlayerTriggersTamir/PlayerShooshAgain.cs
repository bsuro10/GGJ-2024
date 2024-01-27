using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerShooshAgain : PlayerTrigger
{
    public FootstepSoundSwitcher footstepSoundSwitcher;
    public GameObject boots;
    protected override void OnPlayerTriggerEnter()
    {
        footstepSoundSwitcher.StartSqueeky();
        boots.SetActive(true);
    }
}
