using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class CustomerEntersStoreState : IStateCommand
{
    public TMP_Text CustomerNameText;
    public TMP_Text CustomerPositiveTraitText;
    public TMP_Text CustomerNegativeTraitText;

    public override void Enter()
    {
        Debug.Log("CustomerEntersStoreState");
        CustomerStateMachine.Instance.CustomerGameObject.transform.DOMoveX(2, 2.125f)
        .SetEase(Ease.Linear)
        .OnComplete(() => 
        {
            SetText();
            CustomerStateMachine.Instance.CustomerGameObject.GetComponentInChildren<Animator>().SetBool("Walking", false);
        });
    }

    private void SetText()
    {
        CustomerNameText.text          = GameManager.Instance.CharacterDataSO.Name[Random.Range(0, GameManager.Instance.CharacterDataSO.Name.Length)];
        CustomerPositiveTraitText.text = GameManager.Instance.CharacterDataSO.PositiveTrait[Random.Range(0, GameManager.Instance.CharacterDataSO.PositiveTrait.Length)]; 
        CustomerNegativeTraitText.text = GameManager.Instance.CharacterDataSO.NegativeTrait[Random.Range(0, GameManager.Instance.CharacterDataSO.NegativeTrait.Length)];
        Exit();
    }   

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.ChangeState<CustomerTalkingState>();
    }
}
