using UnityEngine;
using UnityEngine.UI;

public class DebtSliderController : MonoBehaviour
{
    public Slider debtSlider; 
    public Text debtText; 
    private float currentDebt = 0f; 
    private float maxDebt = 100f; 

    void Start()
    {
        InitializeSlider();
    }

    private void InitializeSlider()
    {
        if (debtSlider != null)
        {
            debtSlider.maxValue = maxDebt;
            debtSlider.value = currentDebt;
        }
        UpdateDebtText();
    }

    public void SetMaxDebt(float max)
    {
        maxDebt = max;
        if (debtSlider != null)
        {
            debtSlider.maxValue = maxDebt;
        }
        UpdateDebtText();
    }

    public void UpdateDebt(float debt)
    {
        currentDebt = Mathf.Clamp(debt, 0, maxDebt);
        if (debtSlider != null)
        {
            debtSlider.value = currentDebt;
        }
        UpdateDebtText();
    }

    public void AddDebt(float amount)
    {
        UpdateDebt(currentDebt + amount);
    }

    public void ReduceDebt(float amount)
    {
        UpdateDebt(currentDebt - amount);
    }

    private void UpdateDebtText()
    {
        if (debtText != null)
        {
            float percentage = (currentDebt / maxDebt) * 100f;
            debtText.text = $"{percentage}%";
        }
    }
}