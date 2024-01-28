using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomCustomizetion : MonoBehaviour
{
    void OnEnable()
    {
        int _randomIndex = Random.Range(0, transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == _randomIndex)
            {
                continue;
            }
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
