using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultCalculation : MonoBehaviour
{
    //Gameobjects
    public GameObject Liker;
    TextMeshProUGUI LikerTXT;
    public GameObject Hater;
    TextMeshProUGUI HaterTXT;
    public GameObject TotalFan;
    TextMeshProUGUI TotalTXT;
    public GameObject FanGainDisplay;
    TextMeshProUGUI GainTXT;
    public GameObject CloseButton;
    public AudioSource vocalFry;
    //components and data
    Animator animator;
    public Animator TransAnime;
    int FanGain;
    int FanGainIncrease=0;
    public GameObject SalaryDisplay;
    float Salary;
    float SalaryIncrease=0;
    TextMeshProUGUI SalaryTXT;
    
    private void Awake() {
        animator=GetComponent<Animator>();
        LikerTXT=Liker.GetComponentInChildren<TextMeshProUGUI>();
        HaterTXT=Hater.GetComponentInChildren<TextMeshProUGUI>();
        TotalTXT=TotalFan.GetComponentInChildren<TextMeshProUGUI>();
        GainTXT=FanGainDisplay.GetComponentInChildren<TextMeshProUGUI>();
        SalaryTXT=SalaryDisplay.GetComponentInChildren<TextMeshProUGUI>();

    }
    public void RecordValue()
    {
        LikerTXT.text=string.Format("{0}",DataManager.Likers);
        HaterTXT.text=string.Format("{0}",DataManager.Haters);
        TotalTXT.text=string.Format("{0}",DataManager.FanSum);
        animator.SetTrigger("Display");
        StartCoroutine(DisplayFan());
    }
    IEnumerator DisplayFan()
    {
                        while(vocalFry.volume>0)
                {
                    yield return new WaitForSecondsRealtime(0.01f);
                    vocalFry.volume-= 0.01f;
                }
        yield return new WaitForSecondsRealtime(1);
        Liker.GetComponent<CanvasGroup>().alpha=1;
        yield return new WaitForSecondsRealtime(0.5f);
        Hater.GetComponent<CanvasGroup>().alpha=1;
        yield return new WaitForSecondsRealtime(0.5f);
        TotalFan.GetComponent<CanvasGroup>().alpha=1;
        yield return new WaitForSecondsRealtime(0.5f);
        FanGainDisplay.GetComponent<CanvasGroup>().alpha=1;
        FanGain=DataManager.FanSum-DataManager.PreviousFanSum;
        switch(FanGain)
        {
            case >=0:
                while(FanGainIncrease<=FanGain)
                {
                    GainTXT.text=string.Format("Fan Gained: {0}",FanGainIncrease);
                    yield return new WaitForSecondsRealtime(.001f);
                    if(FanGainIncrease<FanGain)
                    {
                        FanGainIncrease++;
                    }
                    else break;
                }
                break;
            case <0:
                while(FanGainIncrease>=FanGain)
                {
                    GainTXT.text=string.Format("Fan Gained: {0}",FanGainIncrease);
                    yield return new WaitForSecondsRealtime(.001f);
                    if(FanGainIncrease>FanGain)
                    {
                        FanGainIncrease--;
                    }
                    else break;
                }
                break;

        }
        yield return new WaitForSecondsRealtime(0.5f);
        SalaryDisplay.GetComponent<CanvasGroup>().alpha=1;
        Salary=Mathf.RoundToInt(DataManager.FanSum* Random.Range(6,7));
        DataManager.money=Salary;
        while(SalaryIncrease<=Salary)
        {
            SalaryTXT.text=string.Format("Income: {0}",SalaryIncrease);
            yield return new WaitForSecondsRealtime(.0002f);
            if(SalaryIncrease<Salary)
            {
                SalaryIncrease++;
            }
            else break;
        }
        yield return new WaitForSecondsRealtime(0.5f);
        CloseButton.GetComponent<CanvasGroup>().alpha=1;

    }
    
    public void ToIntermission()
    {
        TransAnime.SetTrigger("close");
        StartCoroutine(intermission_cd());
    }
    IEnumerator intermission_cd()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(2);
    }

}
