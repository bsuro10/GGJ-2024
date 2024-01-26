using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooshPlayerTrigger : PlayerTrigger
{
    public Door officeToHallwayDoor;
    protected override void OnPlayerTriggerEnter()
    {
        officeToHallwayDoor.Close();
        AudioManager.Instance.PlayVoiceline("be_quiet");
    }
}
