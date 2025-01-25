using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;        // �̵� UI �� GameObject���� Canvas ����壩
    public AudioSource audioSource;  // �������ֵ� AudioSource

    // �ر��̵겢ֹͣ���ֵĺ���
    public void CloseShop()
    {
        // �ر��̵� UI�����Խ��� Canvas �������� GameObject��
        if (shopUI != null)
        {
            shopUI.SetActive(false);  // �����̵� UI
        }

        // ֹͣ���ֲ���
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // ֹͣ��Ƶ
        }

        Debug.Log("Shop UI closed and music stopped.");
    }
}