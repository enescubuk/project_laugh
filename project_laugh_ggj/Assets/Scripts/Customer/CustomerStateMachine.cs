using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomerStateMachine : MonoBehaviour
{
    public IStateCommand CurrentState;
    private bool InTransition;
    public static CustomerStateMachine Instance;

    public bool IsCustomerSellable;
    [HideInInspector]public GameObject GaveGift;
    [HideInInspector]public GameObject CustomerGameObject;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Bu, mevcut olmayan bir örneği yok eder.
        }
    }

    public void SoundFeedBack(AudioClip _audioClip)
    {
        GetComponent<AudioSource>().clip = _audioClip;
        GetComponent<AudioSource>().Play();
    }

    private void Start() 
    {// Oyun başladığında varsayılan durumu ayarlamak için kullanılır.
        InititeNewState(GetComponent<CustomerGenerateState>());
    }

    public void ChangeState<T>() where T : IStateCommand
    {// Belirtilen türdeki yeni duruma geçişi sağlar.
        T targetState = GetComponent<T>();
        if (targetState == null)
        {
            Debug.Log("tried to change to null state");
        }
        InititeNewState(targetState);
    }

    void InititeNewState(IStateCommand targetState)
    {// Hedef duruma geçişi başlatır, eğer farklıysa ve geçiş yapmıyorsa.
        if (CurrentState != targetState && !InTransition)
        {
            CallNewState(targetState);
        }
    }

    void CallNewState(IStateCommand newState)
    {// Yeni duruma geçiş yapar ve ilgili durum metotlarını çağırır.
        InTransition = true;
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
        InTransition = false;
    }

    private void Update()
    {
        if (CurrentState != null && !InTransition)
        {
            CurrentState.Tick();
        }
    }
}