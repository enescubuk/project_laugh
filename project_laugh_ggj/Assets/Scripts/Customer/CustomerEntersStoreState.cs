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
    public AudioClip DoorOpenSound;

    public override void Enter()
    {
        Debug.Log("CustomerEntersStoreState");
        CustomerStateMachine.Instance.SoundFeedBack(DoorOpenSound);
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
        CustomerNameText.text          = GameManager.Instance.CharacterDataSO.Name[Random.Range(0, GameManager.Instance.CharacterDataSO.Name.Count)];
        CustomerPositiveTraitText.text = GameManager.Instance.CharacterDataSO.PositiveTrait[Random.Range(0, GameManager.Instance.CharacterDataSO.PositiveTrait.Count)]; 
        CustomerNegativeTraitText.text = GameManager.Instance.CharacterDataSO.NegativeTrait[Random.Range(0, GameManager.Instance.CharacterDataSO.NegativeTrait.Count)];
        Exit();
    }   

    public void DoNullText()
    {
        CustomerNameText.text          = null;
        CustomerPositiveTraitText.text = null; 
        CustomerNegativeTraitText.text = null;
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        CustomerStateMachine.Instance.IsCustomerSellable = true;
        CustomerStateMachine.Instance.ChangeState<CustomerTalkingState>();
    }
}
