using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopMangerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public static float coins;
    public Text CoinTxt;
    public string[] itemFunctions;
    public string[] itemDescriptions;
    public string[] itemRightDetails;
    public string[] itemRightExplainations;
    public int selectedItemID = -1;
    void Start()
    {
        coins = DataManager.money;
        CoinTxt.text = "Coins: " + coins.ToString();
        // ID is
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        // Price is
        shopItems[2, 1] = 300;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 300;
        shopItems[2, 4] = 200;
        // Quantity is
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
        itemFunctions = new string[] {
            "",
            "灰流量",
            "无限泡影",
            "增殖的G",
            "腔娱与惊\n谩之互(联网）",
            "Function for item 5"
        };
        itemDescriptions = new string[] {
            "",
            "减少黑粉",
            "清除恶评",
            "粉丝增速up",
            "黑粉数量upup",
            "Description for item 5"
        };
        itemRightDetails = new string[] {
            "",
            "购买后立即生效，\n减少黑粉数量",
            "手动触发，可以删除现在屏幕\n上的所有的恶评及aoe预兆",
            "携带时自动触发，\n增加粉丝增长速度",
            "大幅增加黑粉数量\n（同时也代表增加了总粉丝数）",
            "Right details for item 5"
        };
        itemRightExplainations = new string[] {
            "",
            "采用高端5G技术\n——wireless impermanence! ",
            "全局掌控灰色产业",
            "你长大以后想干什么？\n -开发5G！！！",
            "黑红也是红\n——米线山",
            "Right details for item 5"
        };
    }
    public Sprite GetItemImage(int itemID)
    {
        string imagePath = "Images/Item" + itemID;  // Assuming images are in Resources/Images folder
        Sprite itemSprite = Resources.Load<Sprite>(imagePath);
        if (itemSprite != null)
        {
            return itemSprite;
        }
        else
        {
            Debug.LogError("Failed to load image for item ID: " + itemID);
            return null;
        }
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

