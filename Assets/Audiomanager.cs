using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioSource audioSource; // ���ڲ������ֵ� AudioSource ���

    // ����Ϸ��ʼʱ��������
    void Start()
    {
        // ȷ�� AudioSource �Ѿ�����
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play(); // ��������
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned or is already playing.");
        }
    }
}
