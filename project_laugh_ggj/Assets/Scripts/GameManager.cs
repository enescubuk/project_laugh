using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CharacterDataSO CharacterDataSO;
    public RequestSO RequestSO;
    public AnswersSO PositiveAnswersSO;
    public AnswersSO NeutralAnswersSO;
    public AnswersSO NegativeAnswersSO;
    public int Money;
    public TMP_Text MoneyText;
    public int Day;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    void Start()
    {
        if (GameObject.FindWithTag("MoneyText").GetComponent<TMP_Text>() != null)
        {
            MoneyText = GameObject.FindWithTag("MoneyText").GetComponent<TMP_Text>();
        }
        AddMoney(0);
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        if (MoneyText != null)
        {
            MoneyText.text = Money.ToString();
        }
    }
}
