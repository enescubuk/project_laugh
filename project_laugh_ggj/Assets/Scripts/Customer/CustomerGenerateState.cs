using UnityEngine;

public class CustomerGenerateState : IStateCommand
{
    public GameObject CustomerPrefab;
    public Transform SpawnPoint;
    
    public override void Enter()
    {
        Debug.Log("CustomerGenerateState");
        CustomerStateMachine.Instance.CustomerGameObject = Instantiate(CustomerPrefab, SpawnPoint.position, Quaternion.identity,transform);
        CustomerStateMachine.Instance.IsCustomerSellable = false;
    }

    

    public override void Tick()
    {
        Exit();
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerEntersStoreState>();
    }
}