using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject toolTip;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
   
    public void Help()
    {
        toolTip.SetActive(true);
    }

    public void CloseHelp()
    {
        toolTip.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
