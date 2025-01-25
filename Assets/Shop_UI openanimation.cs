using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UIopenanimation : MonoBehaviour
{
    public Animator shopAnimator;  // ���� Shop UI �� Animator
    public GameObject shopUI;      // ���� Shop UI GameObject��ͨ���� Canvas �� Panel��
    private bool shopUIShown = false;  // ��� Shop UI �Ƿ��Ѿ���ʾ��

    // �󶨵���ť�ĵ���¼�
    public void ShowShopUI()
    {
        // ��� Shop UI �Ѿ���ʾ�������ٽ����κβ���
        if (shopUIShown) return;

        // ���� Shop UI�����֮ǰ���أ�
        shopUI.SetActive(true);

        // ������������
        shopAnimator.SetTrigger("ShowShopUI");

        // ��� Shop UI �Ѿ���ʾ��
        shopUIShown = true;

        Debug.Log("Shop UI shown and animation started.");
    }
}
