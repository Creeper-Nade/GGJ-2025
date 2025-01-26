using UnityEngine;
using UnityEngine.UI; // 如果用普通的 InputField 和 Text
using TMPro; // 如果用 TextMeshPro 的 InputField 和 Text

public class InputValidator : MonoBehaviour
{
    public TMP_InputField inputField; // 输入框
    public Button submitButton; // 提交按钮
    public TMP_Text currentMoneyText; // 显示当前金钱的文本
    //public float currentMoney = DataManager.money; // 当前的金钱

    public DebtSliderController debtSliderController;
    public DataManager dataManager;

    void Start()
    {
        // 初始化显示当前金钱
        UpdateCurrentMoneyText();

        // 限制输入框为整数
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

        // 添加按钮点击事件
        submitButton.onClick.AddListener(ValidateInput);
    }

    void ValidateInput()
    {
        // 检查输入是否是有效的整数
        if (int.TryParse(inputField.text, out int inputValue))
        {
            if (inputValue <= DataManager.money)
            {
                Debug.Log("输入的值是有效的: " + inputValue);
                // 在这里执行扣除金钱或其他逻辑
                DataManager.money -= inputValue;
                UpdateCurrentMoneyText(); // 更新当前金钱显示
                debtSliderController.AddDebt(inputValue);
            }
            else
            {
                Debug.LogWarning("输入的值不能大于当前金钱: " + DataManager.money);
            }
        }
        else
        {
            Debug.LogWarning("请输入一个有效的整数！");
        }
    }

    void UpdateCurrentMoneyText()
    {
        // 更新显示当前金钱的文本
        currentMoneyText.text = "Current Money: " + DataManager.money;
    }
}