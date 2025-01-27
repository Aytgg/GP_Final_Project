using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_sc : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Slider masterVolumeSlider;

    void Start()
    {
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void LoadScene(int _idx)
    {
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
