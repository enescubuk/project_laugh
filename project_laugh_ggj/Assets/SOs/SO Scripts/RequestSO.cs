using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RequestSO", menuName = "SOs/RequestSO")]
public class RequestSO : ScriptableObject
{
    public Request[] Requests;
}

[System.Serializable]
public class Request
{
    [TextArea]
    public string RequestText;
    public List<GameObject> PositiveGifts;
    public List<GameObject> NeutralGifts;
    public List<GameObject> NegativeGifts;
}
