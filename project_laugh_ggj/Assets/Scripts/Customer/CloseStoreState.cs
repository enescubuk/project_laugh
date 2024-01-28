using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CloseStoreState : IStateCommand
{
    public GameObject StorePage;
    public InventorySystem InventorySystem;
    public GameObject OptionButton;
    private Vector2 originalPosition;
    public RectTransform MarketMarketPosition;
    public override void Enter()
    {
        originalPosition = OptionButton.GetComponent<RectTransform>().anchoredPosition;
        OptionButton.GetComponent<RectTransform>().anchoredPosition = MarketMarketPosition.anchoredPosition;
        Debug.Log("CloseStoreState");
        StorePage.SetActive(true);

        
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        GetComponent<CustomerGoesOutState>().Clock.GetComponent<ClockModifier>().Start();
        StorePage.SetActive(false);
        InventorySystem.ActiveItem();
        CustomerStateMachine.Instance.ChangeState<CustomerGenerateState>();
        OptionButton.GetComponent<RectTransform>().anchoredPosition = originalPosition;
    }
}
