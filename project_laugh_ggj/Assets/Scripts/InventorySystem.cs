using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> InventoryList ;
    
    void Start()
    {
        for (int i = 0; i < InventoryList.Count; i++)
        {
            int j = Random.Range(0, InventoryList.Count);
            GameObject temp = InventoryList[i];
            InventoryList.RemoveAt(j);
            InventoryList.Add(temp);
        }
        if (InventoryList.Count > 7)
        {
            InventoryList.RemoveRange(7, InventoryList.Count-7);
        }
        ActiveItem();  
    }
    public void BuyButton()
    {
        GameObject _button = EventSystem.current.currentSelectedGameObject;
        int _cost = _button.GetComponent<MarketItem>().Cost;
        if (GameManager.Instance.Money >= _cost)
        {
            GameManager.Instance.AddMoney(-_cost);
            Debug.Log("Buy");
            AddItemsToInventory(_button);
            _button.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    private void AddItemsToInventory(GameObject _item)
    {
        InventoryList.Add(_item);
    }   

    public void ActiveItem()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            bool isActive = false; // Önce varsayılan olarak çocuğun pasif olduğunu varsayalım.
    
            for (int j = 0; j < InventoryList.Count; j++)
            {
                if (child.name == InventoryList[j].name)
                {
                    isActive = true; // Eğer eşleşme varsa çocuğu aktif etmeyi planlayalım.
                    break; // Eşleşme bulduktan sonra iç döngüyü kıralım.
                }
            }
    
            child.SetActive(isActive); // Çocuğu, eşleşme durumuna göre aktif veya pasif yapalım.
        }
    }

}

