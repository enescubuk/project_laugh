using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataSO", menuName = "SOs/CharacterDataSO")]
public class CharacterDataSO : ScriptableObject
{
    public List<string> Name;
    public List <string> PositiveTrait;
    public List <string> NegativeTrait;
}

