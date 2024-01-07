using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingsManager : MonoBehaviour
{
    public int FC, H, NUM;
    public Text hTxt, fcTxt, numTxt;

    // Start is called before the first frame update
    void Start()
    {
        FC = PlayerPrefs.GetInt("FC");
        H = PlayerPrefs.GetInt("H");
        NUM = PlayerPrefs.GetInt("NUM");
        Check();
    }

    // Update is called once per frame
    void Update()
    {
        ModifyText();
    }

    void ModifyText()
    {
        if (H == 1) hTxt.text = "Low";
        else if(H == -1) hTxt.text = "High";

        if (FC == 1) { fcTxt.text = "Off"; fcTxt.color = new Color(255, 0, 0); }
        else if (FC == -1) { fcTxt.text = "On"; fcTxt.color = new Color(0, 255, 0); }

        numTxt.text = NUM.ToString();
    }

    public void ModifHeight()
    {
        H *= -1;
        PlayerPrefs.SetInt("H" , H);
    }

    public void ModifFieldCentering()
    {
        FC *= -1;
        PlayerPrefs.SetInt("FC", FC);
    }

    public void AddNum()
    {
        if(NUM <= 45)
        {
            NUM += 5;
            PlayerPrefs.SetInt("NUM", NUM);
        }
    }

    public void SubstractNum()
    {
        if (NUM >= 15)
        {
            NUM -= 5;
            PlayerPrefs.SetInt("NUM", NUM);
        }
    }

    void Check()
    {
        if(H != 1 && H != -1)
        {
            H = 1;
        }

        if(FC != 1 && FC != -1)
        {
            FC = 1;
        }

        if (NUM < 10 || NUM > 50)
        {
            NUM = 10;
        }
    }
}
