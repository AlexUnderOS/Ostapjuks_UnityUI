using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public string sceneName;
    public float delaySeconds;
    private void Start()
    {
        Invoke("LoadSceneWithDelay", delaySeconds);
    }

    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(sceneName);
    }
}
