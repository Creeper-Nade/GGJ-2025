using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public ResultCalculation calculate;
    public Animator animator;
    private float time = 90f;
    private bool Zawarudo = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        calculate = GameObject.FindObjectOfType<ResultCalculation>();
    }

    void Start()
    {
        time = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (!Zawarudo)
        {
            Zawarudo = true;
            StartCoroutine(TimesUP());
        }
    }

    IEnumerator TimesUP()
    {
        animator.SetTrigger("TimesUp");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.8f);
        calculate.RecordValue();
    }
}
