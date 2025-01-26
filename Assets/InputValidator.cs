using UnityEngine;
using UnityEngine.UI; // �������ͨ�� InputField �� Text
using TMPro; // ����� TextMeshPro �� InputField �� Text

public class InputValidator : MonoBehaviour
{
    public TMP_InputField inputField; // �����
    public Button submitButton; // �ύ��ť
    public TMP_Text currentMoneyText; // ��ʾ��ǰ��Ǯ���ı�
    //public float currentMoney = DataManager.money; // ��ǰ�Ľ�Ǯ

    public DebtSliderController debtSliderController;
    public DataManager dataManager;

    void Start()
    {
        // ��ʼ����ʾ��ǰ��Ǯ
        UpdateCurrentMoneyText();

        // ���������Ϊ����
        inputField.contentType = TMP_InputField.ContentType.IntegerNumber;

        // ��Ӱ�ť����¼�
        submitButton.onClick.AddListener(ValidateInput);
    }

    void ValidateInput()
    {
        // ��������Ƿ�����Ч������
        if (int.TryParse(inputField.text, out int inputValue))
        {
            if (inputValue <= DataManager.money)
            {
                Debug.Log("�����ֵ����Ч��: " + inputValue);
                // ������ִ�п۳���Ǯ�������߼�
                DataManager.money -= inputValue;
                UpdateCurrentMoneyText(); // ���µ�ǰ��Ǯ��ʾ
                debtSliderController.AddDebt(inputValue);
            }
            else
            {
                Debug.LogWarning("�����ֵ���ܴ��ڵ�ǰ��Ǯ: " + DataManager.money);
            }
        }
        else
        {
            Debug.LogWarning("������һ����Ч��������");
        }
    }

    void UpdateCurrentMoneyText()
    {
        // ������ʾ��ǰ��Ǯ���ı�
        currentMoneyText.text = "Current Money: " + DataManager.money;
    }
}