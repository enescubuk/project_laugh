using UnityEngine;
using DG.Tweening;

public class CustomerGoesOutState : IStateCommand
{

    public GameObject Clock;
    public override void Enter()
    {
        Debug.Log("CustomerGoesOutState");
        GetComponent<CustomerEntersStoreState>().DoNullText();
        CustomerStateMachine.Instance.CustomerGameObject.transform.DOMoveX(GetComponent<CustomerGenerateState>().SpawnPoint.position.x * -1, 3).onComplete += () => 
        Exit();
        CustomerStateMachine.Instance.CustomerGameObject.GetComponentInChildren<Animator>().SetBool("GoesOut", true);
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        Destroy(CustomerStateMachine.Instance.CustomerGameObject);
        CustomerStateMachine.Instance.CustomerGameObject = null;
        if (Clock.GetComponent<ClockModifier>()._currentTime < 0.5)
        {
            CustomerStateMachine.Instance.ChangeState<CloseStoreState>();
        }
        else
        {
            CustomerStateMachine.Instance.ChangeState<CustomerGenerateState>();
        }
    }
}