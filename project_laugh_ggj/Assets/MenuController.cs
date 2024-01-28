using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private bool isPanelOpen;
    [SerializeField] private GameObject Menu;

    public void OptionButton()
    {
        if (isPanelOpen)
        {
            Menu.SetActive(false);
            isPanelOpen = false;
        }
        else
        {
            Menu.SetActive(true);
            isPanelOpen=true;
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
