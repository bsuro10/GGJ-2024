using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject blackScreenCanvas;

    private void Start()
    {
        blackScreenCanvas.SetActive(true);
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(11f);
        SceneManager.LoadScene(0);
    }
}
