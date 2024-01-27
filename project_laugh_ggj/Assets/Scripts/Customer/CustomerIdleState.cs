using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerIdleState : IStateCommand
{
    
    public override void Enter()
    {
        Debug.Log("CustomerIdleState");
        CustomerStateMachine.Instance.CustomerGameObject.GetComponentInChildren<Animator>().SetBool("Idle", true);
    }

    public override void Tick()
    {
        
    }

    private void OtherExit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerTalkingState>();
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerReactionState>();
    }
}
