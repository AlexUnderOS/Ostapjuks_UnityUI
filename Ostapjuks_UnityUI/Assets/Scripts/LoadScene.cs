using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int delayMS = 3000;
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public async void LoadSceneWithDelay(string sceneName)
    {
        await Task.Delay(delayMS);
        Load(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
