using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerTalkingState : IStateCommand
{
    public GameObject SpeechBallonn;
    [HideInInspector]public int RandomRequest;
    public override void Enter()
    {
        Debug.Log("CustomerTalkingState");
        SpeechBallonn.SetActive(true);
        RandomRequest = Random.Range(0, GameManager.Instance.RequestSO.Requests.Length);
        SpeechBallonn.GetComponentInChildren<TMP_Text>().text = GameManager.Instance.RequestSO.Requests[RandomRequest].RequestText;
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        SpeechBallonn.GetComponentInChildren<TMP_Text>().text = null;
        CustomerStateMachine.Instance.ChangeState<CustomerIdleState>();

    }
}
