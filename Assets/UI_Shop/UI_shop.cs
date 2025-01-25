using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplete;
    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplete = container.Find("shopItemTemplete");
        shopItemTemplete.gameObject.SetActive(false);
    }
}
