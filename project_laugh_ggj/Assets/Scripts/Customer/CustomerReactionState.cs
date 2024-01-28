using UnityEngine;
using TMPro;
public class CustomerReactionState : IStateCommand
{
    private GameObject speechBallonn;
    private int RequestIndex;
    private string answerText;
    public float ReactionDuration = 2f;

    public AudioClip[] HappySounds;
    public AudioClip[] NeutralSounds;
    public AudioClip[] SadSounds;

    
    public override void Enter()
    {
        speechBallonn = GetComponent<CustomerTalkingState>().SpeechBallonn;
        Debug.Log("CustomerReactionState");
        CustomerStateMachine.Instance.IsCustomerSellable = false;
        RequestIndex = GetComponent<CustomerTalkingState>().RandomRequest;
        CheckGiftQualityAndGiveAnswers();
        speechBallonn.GetComponentInChildren<TMP_Text>().text = answerText;
        Invoke("Exit", ReactionDuration);
    }

    private void CheckGiftQualityAndGiveAnswers()
    {
        int maxListLength = Mathf.Max(GameManager.Instance.RequestSO.Requests[RequestIndex].PositiveGifts.Count,GameManager.Instance.RequestSO.Requests[RequestIndex].NegativeGifts.Count,GameManager.Instance.RequestSO.Requests[RequestIndex].NeutralGifts.Count);
        for (int i = 0; i < maxListLength; i++)
        {
            if (GameManager.Instance.RequestSO.Requests[RequestIndex].PositiveGifts.Count > i && GameManager.Instance.RequestSO.Requests[RequestIndex].PositiveGifts[i].name == CustomerStateMachine.Instance.GaveGift.name)
            {
                answerText = GameManager.Instance.PositiveAnswersSO.AnswerText[Random.Range(0, GameManager.Instance.PositiveAnswersSO.AnswerText.Count)];
                CustomerStateMachine.Instance.CustomerGameObject.GetComponentInChildren<ControlFace>().Happy();
                CustomerStateMachine.Instance.SoundFeedBack(HappySounds[Random.Range(0, HappySounds.Length)]);
                GameManager.Instance.AddMoney(Random.Range(8,11));
                break;
            }
            else if (GameManager.Instance.RequestSO.Requests[RequestIndex].NeutralGifts.Count > i&& GameManager.Instance.RequestSO.Requests[RequestIndex].NeutralGifts[i].name == CustomerStateMachine.Instance.GaveGift.name)
            {
                answerText = GameManager.Instance.NeutralAnswersSO.AnswerText[Random.Range(0, GameManager.Instance.NeutralAnswersSO.AnswerText.Count)];
                CustomerStateMachine.Instance.CustomerGameObject.GetComponentInChildren<ControlFace>().Neutral();
                GameManager.Instance.AddMoney(Random.Range(4,8));
                break;
            }
            else if (GameManager.Instance.RequestSO.Requests[RequestIndex].NegativeGifts.Count > i&& GameManager.Instance.RequestSO.Requests[RequestIndex].NegativeGifts[i].name == CustomerStateMachine.Instance.GaveGift.name)
            {
                answerText = GameManager.Instance.NegativeAnswersSO.AnswerText[Random.Range(0, GameManager.Instance.NegativeAnswersSO.AnswerText.Count)];
                CustomerStateMachine.Instance.CustomerGameObject.GetComponentInChildren<ControlFace>().Sad();
                GameManager.Instance.AddMoney(Random.Range(1,4));
                break;
            }
        }
    }
    public override void Tick()
    {
    }

    public override void Exit()
    {
        speechBallonn.SetActive(false);
        CustomerStateMachine.Instance.ChangeState<CustomerGoesOutState>();
    }
}