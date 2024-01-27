using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CharacterDataSO CharacterDataSO;
    public RequestSO RequestSO;
    public AnswersSO PositiveAnswersSO;
    public AnswersSO NeutralAnswersSO;
    public AnswersSO NegativeAnswersSO;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }
}
