using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_sc : MonoBehaviour
{
    public static bool isPaused = false;
    private bool isAxisInUse = false;

    GameObject PauseMenuObject = null;

    void Start()
    {
        PauseMenuObject = GameObject.Find("PauseMenuCanvas").transform.Find("PauseMenu").gameObject;
        PauseMenuObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetAxis("Escape") > 0)
        {
            if (!isAxisInUse)
            {
                isAxisInUse = true;

                if (!isPaused)
                    PauseGame();
                else
                    ResumeGame();
            }
        } else
            isAxisInUse = false;
    }

    public void ResumeGame()
    {
        PauseMenuObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void PauseGame()
    {
        PauseMenuObject.SetActive(true);
        Time.timeScale = 0.001f;
        isPaused = true;
    }

    public void LoadScene(int _idx)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadSceneCoroutine(_idx));
    }

    IEnumerator LoadSceneCoroutine(int _idx)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(_idx);
        GameManager_sc.currentScene = _idx;
        while (!asyncload.isDone)
            yield return null;
    }
}
