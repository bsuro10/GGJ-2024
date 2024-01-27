using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private Item bookItem;

    public void SetCollectible()
    {
        Collectible collectible = this.AddComponent<Collectible>();
        collectible.item = bookItem;
    }
}
