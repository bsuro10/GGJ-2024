using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectActivation : MonoBehaviour
{
    public void SetActive(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void SetInActive(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

}
