using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClocheSound : MonoBehaviour
{
    public void PlayVoiceline()
    {
        AudioManager.Instance.PlayVoiceline("there_it_is");
    }
}
