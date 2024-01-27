using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFace : MonoBehaviour
{
    public GameObject HappyFace;
    public GameObject NeutralFace;
    public GameObject SadFace;

    void OnEnable()
    {
        Neutral();
    }

    public void Happy()
    {
        NeutralFace.SetActive(false);
        HappyFace.SetActive(true);
        SadFace.SetActive(false);
    }

    public void Neutral()
    {
        NeutralFace.SetActive(true);
        HappyFace.SetActive(false);
        SadFace.SetActive(false);
    }

    public void Sad()
    {
        NeutralFace.SetActive(false);
        HappyFace.SetActive(false);
        SadFace.SetActive(true);
    }
}
