using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float displayDuration = 1.0f;
    public GameObject player;
    public CanvasGroup exitBG;
    public CanvasGroup overBG;

    bool isPlayerExit;
    bool isPlayerOver;
    float timer;

    void Start()
    {
        
        player = GetComponent<GameObject>();
        overBG = GetComponent<CanvasGroup>();
        exitBG.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerExit)
        {
            EndLevel(exitBG, false);
        }
        else if (isPlayerOver)
        {
            EndLevel(overBG, true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerExit = true;
        }
    }


    void EndLevel(CanvasGroup imageCanvas, bool doRestart)
    {
        if (!isPlayerExit)
        {
            exitBG.gameObject.SetActive(true);
        }else if (isPlayerOver)
        {
            overBG.gameObject.SetActive(false);
        }
        
        timer += Time.deltaTime;

        exitBG.alpha = timer / fadeDuration;
        overBG.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }

            else
            {
                Application.Quit();
            }
        }
    }

    public void CaughtPlayer()
    {
        isPlayerOver = true;
    }
}