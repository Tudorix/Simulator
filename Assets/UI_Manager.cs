using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject g1, g2;
    int c = 1;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeObject()
    {
        if(c == 1)
        {
            g1.SetActive(false);
            g2.SetActive(true);
            c *= -1;
        }
        else
        {
            g1.SetActive(true);
            g2.SetActive(false);
            c *= -1;
        }
    }

    public void LoadGame()
    {
        Application.LoadLevel("Game");
    }
}
