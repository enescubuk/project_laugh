using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStateCommand : MonoBehaviour
{
    public virtual void Enter(){}

    public virtual void Tick(){}
    
    public virtual void Exit(){}
}