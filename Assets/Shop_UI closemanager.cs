using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;        // 商店 UI 的 GameObject（如 Canvas 或面板）
    public AudioSource audioSource;  // 播放音乐的 AudioSource

    // 关闭商店并停止音乐的函数
    public void CloseShop()
    {
        // 关闭商店 UI（可以禁用 Canvas 或者隐藏 GameObject）
        if (shopUI != null)
        {
            shopUI.SetActive(false);  // 隐藏商店 UI
        }

        // 停止音乐播放
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // 停止音频
        }

        Debug.Log("Shop UI closed and music stopped.");
    }
}