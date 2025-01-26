using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UImanager : MonoBehaviour
{
    private GameObject Shop_UI;
    void Start()
    {
        Shop_UI = GameObject.Find("Shop_UI");
        Shop_UI.SetActive(true);
    }
   public void OnClickShopHandler()
    {
        Shop_UI.SetActive(Shop_UI.activeSelf == true ? false : true);
    }
}
