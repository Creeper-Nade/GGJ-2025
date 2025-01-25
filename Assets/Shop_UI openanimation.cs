using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UIopenanimation : MonoBehaviour
{
    public Animator shopAnimator;  // 引用 Shop UI 的 Animator
    public GameObject shopUI;      // 引用 Shop UI GameObject（通常是 Canvas 或 Panel）
    private bool shopUIShown = false;  // 标记 Shop UI 是否已经显示过

    // 绑定到按钮的点击事件
    public void ShowShopUI()
    {
        // 如果 Shop UI 已经显示过，则不再进行任何操作
        if (shopUIShown) return;

        // 激活 Shop UI（如果之前隐藏）
        shopUI.SetActive(true);

        // 触发动画播放
        shopAnimator.SetTrigger("ShowShopUI");

        // 标记 Shop UI 已经显示过
        shopUIShown = true;

        Debug.Log("Shop UI shown and animation started.");
    }
}
