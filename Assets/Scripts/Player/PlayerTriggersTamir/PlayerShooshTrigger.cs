using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooshPlayerTrigger : PlayerTrigger
{
    public Door officeToHallwayDoor;
    public bool shooshed = false;
    protected override void OnPlayerTriggerEnter()
    {
        if(!shooshed) 
        {
            officeToHallwayDoor.Close();
            AudioManager.Instance.PlayVoiceline("be_quiet");
            shooshed = true;
        }
    }
}
