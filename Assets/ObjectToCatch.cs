using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCatch : MonoBehaviour
{
    public GameObject[] obj;
    int r;

    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(0, 4);
        obj[r].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "W" && r == 0)
        {
            PlayerPrefs.SetInt("S", PlayerPrefs.GetInt("S") + 1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "G" && r == 1)
        {
            PlayerPrefs.SetInt("S", PlayerPrefs.GetInt("S") + 1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "P" && r == 2)
        {
            PlayerPrefs.SetInt("S", PlayerPrefs.GetInt("S") + 1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "O" && r == 3)
        {
            PlayerPrefs.SetInt("S", PlayerPrefs.GetInt("S") + 1);
            Destroy(this.gameObject);
        }
    }
}
