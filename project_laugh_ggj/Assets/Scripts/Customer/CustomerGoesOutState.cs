using UnityEngine;

public class CustomerGoesOutState : IStateCommand
{
    public override void Enter()
    {
        Debug.Log("CustomerGoesOutState");
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerGenerateState>();
    }
}