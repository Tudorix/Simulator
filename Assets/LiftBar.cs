using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0.6876084f, transform.position.y, -0.66371f);
    }
}
