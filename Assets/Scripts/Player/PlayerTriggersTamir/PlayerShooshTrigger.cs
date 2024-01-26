using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooshPlayerTrigger : PlayerTrigger
{
    protected override void OnPlayerTriggerEnter()
    {
        // Close door
        print("close door");
        AudioManager.Instance.PlayVoiceline("be_quiet");
    }
}
