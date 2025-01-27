using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_sc : MonoBehaviour
{
    public static GameObject instance;
    public static int currentScene = 0;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        } else
            Destroy(this.gameObject);
    }
}
