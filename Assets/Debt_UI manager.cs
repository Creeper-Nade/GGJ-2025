using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;
public class Debt_UImanager : MonoBehaviour
{
    public Slider RepaymentSlider;
    public Text debtTxt;
    public Text statusText;
    public ShopMangerScript shopmanagerscript;
    public float coins;
    private float totelDebt;
    private float currentDebt;
    void Start()
    {
        coins = shopmanagerscript.coins;
        statusText.text = "调整滑块偿还债务";
        RepaymentSlider.maxValue= Mathf.Min(coins,totelDebt);
        RepaymentSlider.value = 0;
        RepaymentSlider.onValueChanged.AddListener(RepayDebt);
    }

    void Update()
    {

    }
    void RepayDebt(float RepaymentAmount)
    {
        float actualRepayment=Mathf.Min(coins,totelDebt);
        totelDebt-=actualRepayment;
        coins -= actualRepayment;
        shopmanagerscript.CoinTxt.text = "Coins: " + coins.ToString();
        debtTxt.text = $"Remaining Debt: {Mathf.Max(totelDebt, 0):F2}";
        if (totelDebt <= 0)
        {
            debtTxt.text = "Debt Fully Repaid!";
            RepaymentSlider.interactable = false;
        }
    }
    void UpdateRepaymentSlider()
    {
        RepaymentSlider.maxValue = Mathf.Min(coins, totelDebt);
    }
}
