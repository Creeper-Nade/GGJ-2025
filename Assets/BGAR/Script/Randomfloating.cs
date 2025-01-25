using System.Collections.Generic;
using UnityEngine;

public class FloatingAndRotatingUI : MonoBehaviour
{
    [System.Serializable]
    public class FloatingObject
    {
        public RectTransform imageRectTransform; // ͼƬ�� RectTransform
        public Vector2 initialPosition;          // ��ʼλ��
        public float floatRange = 20f;           // ���¸�����Χ
        public float floatSpeed = 1f;            // �����ٶ�
        public float rotationRange = 5f;         // ��ת�Ƕȷ�Χ����λ���ȣ�
        public float rotationSpeed = 1f;         // ��ת�ٶ�
    }

    public List<FloatingObject> floatingObjects = new List<FloatingObject>();

    private void Start()
    {
        // ��ʼ��ÿ��ͼƬ�ĳ�ʼλ��
        foreach (var obj in floatingObjects)
        {
            if (obj.imageRectTransform != null)
            {
                obj.initialPosition = obj.imageRectTransform.anchoredPosition;
            }
        }
    }

    private void Update()
    {
        // ����ÿ��ͼƬ��λ�ú���ת
        foreach (var obj in floatingObjects)
        {
            if (obj.imageRectTransform != null)
            {
                // ���¸�����ƫ��ֵ
                float verticalOffset = Mathf.Sin(Time.time * obj.floatSpeed + obj.imageRectTransform.GetInstanceID()) * obj.floatRange;

                // ��΢��ת�ĽǶ�
                float rotationAngle = Mathf.Sin(Time.time * obj.rotationSpeed + obj.imageRectTransform.GetInstanceID()) * obj.rotationRange;

                // ����ͼƬλ�ã����¸�����
                obj.imageRectTransform.anchoredPosition = obj.initialPosition + new Vector2(0, verticalOffset);

                // ����ͼƬ��ת����΢��ת��
                obj.imageRectTransform.localRotation = Quaternion.Euler(0, 0, rotationAngle);
            }
        }
    }
}