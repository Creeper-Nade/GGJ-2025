using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rest : MonoBehaviour
{
    public int currentlevel = 1;
    public Image[] emptyHearts;
    public Image[] fullHearts;

    public GameObject debtpanel;

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
        //¼ÓÔØ»¹Õ®°å
    }

    public void CloseDebtPanel()
    {
        SFXManager.Instance.PlaySFX(1);
        debtpanel.SetActive(false);
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
            Debug.Log("¹Ø¿¨³¬³ö·¶Î§¡£");
                return;
        }

        currentlevel = level;

        for(int i = 0; i < currentlevel; i++)
        {
            fullHearts[i].gameObject.SetActive(true);
            emptyHearts[i].gameObject.SetActive(false);
        }
    }
}
