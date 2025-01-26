using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioSource audioSource; // 用于播放音乐的 AudioSource 组件

    // 在游戏开始时播放音乐
    void Start()
    {
        // 确保 AudioSource 已经设置
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // 播放音乐
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned or is already playing.");
        }
    }
}
