using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rest : MonoBehaviour
{
    public static int currentlevel = 1;
    public Image[] emptyHearts;
    public Image[] fullHearts;

    public GameObject debtpanel;

    public GameObject pinkCha;
    public GameObject blueCha;

    // Start is called before the first frame update
    void Start()
    {
        InitializeHearts();

        if(debtpanel != null)
        {
            debtpanel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Leveldisplay(currentlevel);
        resetHeart();
    }

    public void NextLevelGame()
    {
        SFXManager.Instance.PlaySFX(0);
        SceneTransition.Instance.LoadSceneWithFade("InGame");
        currentlevel++;
    }

    public void LoadStore()
    {
        SFXManager.Instance.PlaySFX(0);
        SceneTransition.Instance.LoadSceneWithFade("Store");
    }

    public void LoadMenu()
    {
        SFXManager.Instance.PlaySFX(0);
        Menu.SetPreviousScene(SceneManager.GetActiveScene().name);
        SceneTransition.Instance.LoadSceneWithFade("Menu");
    }

    public void LoadDebtPanel()
    {
        SFXManager.Instance.PlaySFX(0);
        debtpanel.SetActive(true);
        //加载还债板
    }

    public void CloseDebtPanel()
    {
        SFXManager.Instance.PlaySFX(1);
        debtpanel.SetActive(false);
    }

    public void Pinkcha()
    {
        SFXManager.Instance.PlaySFX(2);
        pinkCha.SetActive(true);
        blueCha.SetActive(false);
    }

    public void bluecha()
    {
        SFXManager.Instance.PlaySFX(2);
        pinkCha.SetActive(false);
        blueCha.SetActive(true);
    }
    private void InitializeHearts()
    {
        for (int i = 0; i < fullHearts.Length; i++)
        {
            fullHearts[i].gameObject.SetActive(false);
            emptyHearts[i].gameObject.SetActive(true);
        }
    }

    public void Leveldisplay(int level)
    {
        if(level < 1 || level > emptyHearts.Length)
        {
            Debug.Log("下一大轮。");
                return;
        }

        currentlevel = level;

        for(int i = 0; i < currentlevel; i++)
        {
            fullHearts[i].gameObject.SetActive(true);
            emptyHearts[i].gameObject.SetActive(false);
        }
    }

    public void resetHeart()
    {
        if(currentlevel > 3)
        {
            currentlevel = 1;
        }
    }
}
