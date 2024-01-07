using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public int i = 1;
    public GameObject[] objects;
    public GameObject CatchObj;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("S", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (i != PlayerPrefs.GetInt("S"))
        {
            i = PlayerPrefs.GetInt("S");
            txt.text = "Score : " + i.ToString();
            int r = Random.Range(0, objects.Length);
            Instantiate(CatchObj, objects[r].transform.position, objects[r].transform.rotation);
        }
    }
}
