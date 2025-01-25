using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopMangerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float coins;
    public Text CoinTxt;
    public Sprite[] itemImages;
    public string[] itemFunctions;
    public string[] itemDescriptions;
    public string[] itemRightDetails;
    public int selectedItemID = -1;
    void Start()
    {
        CoinTxt.text = "Coins: " + coins.ToString();
        // ID is
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        // Price is
        shopItems[2, 1] = 100;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 300;
        shopItems[2, 4] = 400;
        // Quantity is
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        itemImages = new Sprite[6]; // Add images for your items here
        itemFunctions = new string[] {
            "",
            "灰流量",
            "无限泡影",
            "Function for item 3",
            "Function for item 4",
            "Function for item 5"
        };
        itemDescriptions = new string[] {
            "",
            "清空黑屏",
            "其他什么功能",
            "Description for item 3",
            "Description for item 4",
            "Description for item 5"
        };
        itemRightDetails = new string[] {
            "",
            "Right details for item 1",
            "Right details for item 2",
            "Right details for item 3",
            "Right details for item 4",
            "Right details for item 5"
        };
    }

    public void PurchaseItem(int itemID)
    {
        // 检查金币是否足够
        if (coins >= shopItems[2, itemID])
        {
            // 扣除金币
            coins -= shopItems[2, itemID];

            // 增加库存
            shopItems[3, itemID]++;

            // 更新 UI
            CoinTxt.text = "Coins: " + coins.ToString();
            Debug.Log($"Item {itemID} purchased! Remaining coins: {coins}");
            Debug.Log($"Item {itemID} purchased! New Quantity: {shopItems[3, itemID]}");
        }
        else
        {
            Debug.Log($"Not enough coins to purchase item {itemID}. Current coins: {coins}");
        }
    }
}

