using UnityEngine;
using UnityEngine.UI;

public class buttoninfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    private void Start()
    {
        ShopMangerScript shopManagerScript = ShopManager.GetComponent<ShopMangerScript>();
        PriceTxt.text = "" + shopManagerScript.shopItems[2, ItemID].ToString();
        QuantityTxt.text = "" + shopManagerScript.shopItems[3, ItemID].ToString();
    }
}