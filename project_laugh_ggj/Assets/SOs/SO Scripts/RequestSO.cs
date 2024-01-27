using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RequestSO", menuName = "SOs/RequestSO")]
public class RequestSO : ScriptableObject
{
    public string[] Requests;
    public GameObject[] PositiveGifts;
    public GameObject[] NeutralGifts;
    public GameObject[] NegativeGifts;
}

