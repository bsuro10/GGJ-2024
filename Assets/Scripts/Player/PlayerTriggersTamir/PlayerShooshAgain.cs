using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooshAgain : PlayerTrigger
{
    protected override void OnPlayerTriggerEnter()
    {
        AudioManager.Instance.PlayVoiceline("shoosh_again");
        // Activate interactable boots under players feet
        // Switch to boots sounds
    }
}
