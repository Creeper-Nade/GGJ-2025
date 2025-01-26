using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_UImanager : MonoBehaviour
{
    public Button[] itemButtons;
    public UnityEngine.UI.Image detailImage;
    public Text priceTextoutput;
    public Text quantityTexttoutput;
    public Text detailFunction;
    public Text rightDetailText;
    public Text rightDetailExplanatins;
    public Text detailDescription;
    public GameObject ShopManager;
    public ShopMangerScript shopManagerScript;
    public Button purchaseButton;
    void Start()
    {
        void Start()
        {
            if (ShopManager == null)
            {
                Debug.LogError("ShopManager is not assigned in Inspector!");
                return;
            }

            shopManagerScript = ShopManager.GetComponent<ShopMangerScript>();
            if (shopManagerScript == null)
            {
                Debug.LogError("ShopManager does not have ShopMangerScript component!");
                return;
            }

            // 继续后续逻辑...
        }
        shopManagerScript = ShopManager.GetComponent<ShopMangerScript>();
        for (int i = 0; i < itemButtons.Length; i++)
        {
            int itemID = i + 1; // 保存当前循环的 itemID
            Button button = itemButtons[i];
            Text priceText = button.transform.Find("Price").GetComponent<Text>();
            Text quantityText = button.transform.Find("Quantity").GetComponent<Text>();


            // 使用局部变量捕获 itemID
            int capturedID = itemID;
            button.onClick.AddListener(() => ShowDetails(capturedID));
        }

    }
    private void ShowDetails(int itemID)
    {
        Debug.Log($"ShowDetails called for itemID: {itemID}");
        shopManagerScript.selectedItemID=itemID;

        // Access the ShopManagerScript
        if (shopManagerScript != null)
        {
            // Set the detail image for the selected item
            detailImage.sprite = shopManagerScript.GetItemImage(itemID);  // Set the corresponding sprite for the item

            // Set the function description for the selected item
            detailFunction.text = "" + shopManagerScript.itemFunctions[itemID]; // Display the function of the item

            // Set the item description
            detailDescription.text = "" + shopManagerScript.itemDescriptions[itemID]; // Display the general description

            // Set the detailed right-side information for the item
            rightDetailText.text = "" + shopManagerScript.itemRightDetails[itemID]; // Display detailed info
            priceTextoutput.text = "" + shopManagerScript.shopItems[2, itemID];
            quantityTexttoutput.text = ""+shopManagerScript.shopItems[3, itemID];
            rightDetailExplanatins.text=""+shopManagerScript.itemRightExplainations[itemID];
        }
        else
        {
            Debug.LogError("shopManagerScript is null, cannot update item details.");
        }
    }
    public void OnPurchaseButtonClicked()
    {
        if(shopManagerScript.selectedItemID!=-1) {
            shopManagerScript.PurchaseItem(shopManagerScript.selectedItemID);
            Button selectedButton = itemButtons[shopManagerScript.selectedItemID - 1];
            Text quantityText = selectedButton.transform.Find("Quantity").GetComponent<Text>();
            quantityText.text = "" + shopManagerScript.shopItems[3, shopManagerScript.selectedItemID].ToString();
            quantityTexttoutput.text = " " + shopManagerScript.shopItems[3, shopManagerScript.selectedItemID].ToString();
            Debug.Log("Purchase completed. UI updated.");
        }
        else
        {
            Debug.Log("No item selected to purchase.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
