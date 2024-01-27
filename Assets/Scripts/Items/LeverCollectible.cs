using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCollectible : Collectible
{
    public override void PickUp()
    {
        AudioManager.Instance.PlayVoiceline("there_it_is");
        base.PickUp();
    }
}
