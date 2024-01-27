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
        // CustomerNameText.text          = GameManager.Instance.CharacterDataSO.CharacterInfo[Random.Range(0, GameManager.Instance.CharacterDataSO.CharacterInfo.Length)].Name;
        // CustomerPositiveTraitText.text = GameManager.Instance.CharacterDataSO.CharacterInfo[Random.Range(0, GameManager.Instance.CharacterDataSO.CharacterInfo.Length)].PositiveTrait;
        // CustomerNegativeTraitText.text = GameManager.Instance.CharacterDataSO.CharacterInfo[Random.Range(0, GameManager.Instance.CharacterDataSO.CharacterInfo.Length)].NegativeTrait;
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
