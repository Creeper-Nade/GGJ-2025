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
        SFXManager.Instance.PlaySFX(0);
        
        SceneTransition.Instance.LoadSceneWithFade("InGame");
        SFXManager.Instance.ChecKbgm();
    }


    public void ExitGame()
    {
        SFXManager.Instance.PlaySFX(0);
        Application.Quit();
    }

    public void Resume()
    {
        SFXManager.Instance.PlaySFX(0);
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneTransition.Instance.LoadSceneWithFade(previousScene);
            SFXManager.Instance.ChecKbgm();
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