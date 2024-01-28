using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void ButtonA()
    {
        SceneManager.LoadScene(1);
        /*cam.transform.DOMove(pos1.transform.position, 2).SetEase(Ease.OutCubic);
        cam.transform.DORotate(pos1.transform.eulerAngles, 2).SetEase(Ease.OutCubic);
        optionPanel.SetActive(false);*
        StartCoroutine(ChangeAfter2());*/

    }
    public void ButtonB()
    {
        Application.Quit();
      /*  cam.transform.DOMove(pos2.transform.position, 2).SetEase(Ease.OutCubic);
        cam.transform.DORotate(pos2.transform.eulerAngles, 2).SetEase(Ease.OutCubic);
        mainPanel.SetActive(false);
        StartCoroutine(ChangeAfter2SecondCoroutine());*/
    }
}
