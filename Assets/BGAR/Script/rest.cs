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

    public DebtSliderController debtSliderController; 


    private int[] maxDebtValues = { 3000, 10000, 30000 };
    private int currentRound = 0; // 当前大轮数

    void Start()
    {
        InitializeHearts();

        if (debtpanel != null)
        {
            debtpanel.SetActive(false);
        }

        if (debtSliderController != null)
        {
            debtSliderController.SetMaxDebt(maxDebtValues[currentRound]);
        }
    }

    void Update()
    {
        Leveldisplay(currentlevel);
    }

    public void NextLevelGame()
    {
        SFXManager.Instance.PlaySFX(0);
        //SceneTransition.Instance.LoadSceneWithFade("InGame");
        currentlevel++;
        //测试保存
        //debtSliderController.AddDebt(1000);

        // 检查是否进入下一轮
        if (currentlevel % 3 == 1) // 每 3 关进入下一大轮
        {
            if(debtSliderController.currentDebt >= debtSliderController.maxDebt)
            {
                UpdateMaxDebt();
                currentlevel = 1;
                InitializeHearts();
            }
            else if(debtSliderController.currentDebt < debtSliderController.maxDebt)
            {
                SceneTransition.Instance.LoadSceneWithFade("Fail");
            }

        }
    }

    private void UpdateMaxDebt()
    {
        if (debtSliderController != null)
        {
            currentRound++;
            if (currentRound >= maxDebtValues.Length)
            {
                currentRound = 0; 
            }

            debtSliderController.currentDebt = 0;
            debtSliderController.SetMaxDebt(maxDebtValues[currentRound]);
            
        }
    }

    public void LoadStore()
    {
        SFXManager.Instance.PlaySFX(0);
        SceneTransition.Instance.LoadSceneWithFade("newScenes");
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
        if (level < 1 || level > emptyHearts.Length)
        {
            Debug.Log("下一大轮。");
            return;
        }

        currentlevel = level;

        for (int i = 0; i < currentlevel; i++)
        {
            fullHearts[i].gameObject.SetActive(true);
            emptyHearts[i].gameObject.SetActive(false);
        }
    }
}