using UnityEngine;

public class CustomerReactionState : IStateCommand
{
    public override void Enter()
    {
        Debug.Log("CustomerReactionState");
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerGoesOutState>();
    }
}