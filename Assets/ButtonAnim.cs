using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    public Text txt;
    int txtFont;

    // Start is called before the first frame update
    void Start()
    {
        txtFont = txt.fontSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        txt.fontSize = txtFont + 10;
    }
}
