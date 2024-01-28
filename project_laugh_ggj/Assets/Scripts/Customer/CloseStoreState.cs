using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseStoreState : IStateCommand
{
    public GameObject StorePage;
    public InventorySystem InventorySystem;
    public override void Enter()
    {
        Debug.Log("CloseStoreState");
        StorePage.SetActive(true);
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        StorePage.SetActive(false);
        InventorySystem.ActiveItem();
        CustomerStateMachine.Instance.ChangeState<CustomerGenerateState>();
    }
}
