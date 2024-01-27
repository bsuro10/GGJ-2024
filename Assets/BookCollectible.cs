using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollectible : Collectible
{
    public override void PickUp()
    {
        Narrator.Instance.setTarget(Narrator.Instance.player);
        base.PickUp();
    }
}
