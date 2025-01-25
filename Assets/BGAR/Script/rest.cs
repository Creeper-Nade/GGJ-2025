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
        SceneManager.LoadScene("Level" + currentlevel);
        //������һ��
        currentlevel++;
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("Store");
        //�����̵�
    }

    public void LoadMenu()
    {
        Menu.SetPreviousScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Menu");
        //�����̵�
    }

    public void LoadDebtPanel()
    {
        debtpanel.SetActive(true);
        //���ػ�ծ��
    }

    public void CloseDebtPanel()
    {
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
            Debug.Log("�ؿ�������Χ��");
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
