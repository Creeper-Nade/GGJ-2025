using System.Collections.Generic;
using UnityEngine;

public class FloatingAndRotatingUI : MonoBehaviour
{
    [System.Serializable]
    public class FloatingObject
    {
        public RectTransform imageRectTransform; // 图片的 RectTransform
        public Vector2 initialPosition;          // 初始位置
        public float floatRange = 20f;           // 上下浮动范围
        public float floatSpeed = 1f;            // 浮动速度
        public float rotationRange = 5f;         // 旋转角度范围（单位：度）
        public float rotationSpeed = 1f;         // 旋转速度
    }

    public List<FloatingObject> floatingObjects = new List<FloatingObject>();

    private void Start()
    {
        // 初始化每个图片的初始位置
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
        // 更新每个图片的位置和旋转
        foreach (var obj in floatingObjects)
        {
            if (obj.imageRectTransform != null)
            {
                // 上下浮动的偏移值
                float verticalOffset = Mathf.Sin(Time.time * obj.floatSpeed + obj.imageRectTransform.GetInstanceID()) * obj.floatRange;

                // 轻微旋转的角度
                float rotationAngle = Mathf.Sin(Time.time * obj.rotationSpeed + obj.imageRectTransform.GetInstanceID()) * obj.rotationRange;

                // 更新图片位置（上下浮动）
                obj.imageRectTransform.anchoredPosition = obj.initialPosition + new Vector2(0, verticalOffset);

                // 更新图片旋转（轻微旋转）
                obj.imageRectTransform.localRotation = Quaternion.Euler(0, 0, rotationAngle);
            }
        }
    }
}