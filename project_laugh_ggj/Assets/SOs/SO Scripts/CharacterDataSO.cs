using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataSO", menuName = "SOs/CharacterDataSO")]
public class CharacterDataSO : ScriptableObject
{
    public CharacterInfo[] CharacterInfo;
}

[System.Serializable]
public class CharacterInfo
{
    public string Name;
    public string PositiveTrait;
    public string NegativeTrait;

}