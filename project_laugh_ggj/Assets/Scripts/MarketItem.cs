using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarketItem : MonoBehaviour
{
    
    public int Cost;

    void OnEnable()
    {
        foreach (GameObject item in GetComponentInParent<MarketManager>().InventorySystem.InventoryList)
        {
            if (item.name == gameObject.name)
            {
                gameObject.SetActive(false);
            }
        }
        GetComponentInChildren<TMP_Text>().text = Cost.ToString();
    }
}
