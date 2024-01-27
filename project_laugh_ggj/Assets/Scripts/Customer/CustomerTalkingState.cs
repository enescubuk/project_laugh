using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerTalkingState : IStateCommand
{
    public GameObject SpeechBallonn;
    public override void Enter()
    {
        SpeechBallonn.SetActive(true);
        SpeechBallonn.GetComponentInChildren<TMP_Text>().text = GameManager.Instance.RequestSO.Requests[Random.Range(0, GameManager.Instance.RequestSO.Requests.Length)].RequestText;
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerIdleState>();
    }
}
