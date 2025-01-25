using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private static string previousScene;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void StartGame()
    {
        SceneTransition.Instance.LoadSceneWithFade("InGame");
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneTransition.Instance.LoadSceneWithFade(previousScene);
        }
        else
        {
            Debug.LogWarning("没有记录上一个场景！");
        }
    }

    public static void SetPreviousScene(string sceneName)
    {
        previousScene = sceneName;
    }
}