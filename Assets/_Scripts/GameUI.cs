using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject depositSignal;

    private void Start()
    {
        depositSignal.SetActive(false);
    }

    public void depoBtn()
    {
        depositSignal.SetActive(true);
    }

    public void menuScene()
    {
        SceneManager.LoadScene("Start");
    }
}
