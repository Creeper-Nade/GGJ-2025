using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnShopUI_manager : MonoBehaviour
{
    private GameObject Shop_UI;
    void Start()
    {
        Shop_UI = GameObject.Find("Shop_UI");
    }
    public void OnClickShopHandler()
    {
        Shop_UI.SetActive(Shop_UI.activeSelf == true ? false : true);
    }

}
