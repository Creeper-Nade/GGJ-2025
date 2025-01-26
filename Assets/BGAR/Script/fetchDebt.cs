using UnityEngine;
using UnityEngine.UI;

public class DebtSliderController : MonoBehaviour
{
    public Slider debtSlider;
    public Text debtText;
    public int currentDebt = 0;
    public int maxDebt = 3000;

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

    public void SetMaxDebt(int max)
    {
        maxDebt = max;
        if (debtSlider != null)
        {
            debtSlider.maxValue = maxDebt;
        }
        UpdateDebtText();
        InitializeSlider();
    }

    public void UpdateDebt(int debt)
    {
        currentDebt = Mathf.Clamp(debt, 0, maxDebt); // ʹ�� Mathf.Clamp
        if (debtSlider != null)
        {
            debtSlider.value = currentDebt;
        }
        UpdateDebtText();
    }

    public void AddDebt(int amount)
    {
        UpdateDebt(currentDebt + amount);
    }

    public void ReduceDebt(int amount)
    {
        UpdateDebt(currentDebt - amount);
    }

    private void UpdateDebtText()
    {
        if (debtText != null)
        {
            // ʹ����������ٷֱ�
            int percentage = (currentDebt * 100) / maxDebt;
            debtText.text = $"{percentage}%"; // ��ʾ�����ٷֱ�
        }
    }

}