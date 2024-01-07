using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveTrain_Movement : MonoBehaviour
{
    public float MSpeed = 5f;
    private float WheelMultiplier = 1f;
    float control = 50, S1, S2;

    public Rigidbody rb;

    private float x, y, turn;

    public bool FieldCentering;
    public Transform RotPoint;

    public GameObject[] wheel = new GameObject[4];

    public int FC, H;
    public GameObject HeightBlock;

    // Start is called before the first frame update
    void Start()
    {
        H = PlayerPrefs.GetInt("H");
        FC = PlayerPrefs.GetInt("FC");

        if(H == -1)
        {
            HeightBlock.SetActive(true);
        }

        if(FC == -1)
        {
            FieldCentering = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (y != 0 && x == 0)
        {
            S1 = y + turn;
            S2 = y - 2 * turn;
            wheel[0].transform.Rotate(Vector3.up * MSpeed * -S1 * Time.deltaTime * control * WheelMultiplier);
            wheel[1].transform.Rotate(Vector3.up * MSpeed * -S1 * Time.deltaTime * control * WheelMultiplier);
            wheel[2].transform.Rotate(Vector3.up * MSpeed * -S2 * Time.deltaTime * control * WheelMultiplier);
            wheel[3].transform.Rotate(Vector3.up * MSpeed * -S2 * Time.deltaTime * control * WheelMultiplier);
        }
        else if (x != 0 && y == 0)
        {
            S1 = -x - turn;
            S2 = x + turn;
            wheel[0].transform.Rotate(Vector3.up * MSpeed * -S1 * Time.deltaTime * control * WheelMultiplier);
            wheel[1].transform.Rotate(Vector3.up * MSpeed * -S1 * Time.deltaTime * control * WheelMultiplier);
            wheel[2].transform.Rotate(Vector3.up * MSpeed * -S2 * Time.deltaTime * control * WheelMultiplier);
            wheel[3].transform.Rotate(Vector3.up * MSpeed * -S2 * Time.deltaTime * control * WheelMultiplier);
        }
        else if (x != 0 && y != 0)
        {
            S1 = x + y + turn;
            S2 = x - y - turn;
            wheel[0].transform.Rotate(Vector3.up * MSpeed * S1 * Time.deltaTime * control);
            wheel[1].transform.Rotate(Vector3.up * MSpeed * S1 * Time.deltaTime * control);
            wheel[2].transform.Rotate(Vector3.up * MSpeed * S2 * Time.deltaTime * control);
            wheel[3].transform.Rotate(Vector3.up * MSpeed * S2 * Time.deltaTime * control);
        }
        else
        {
            S1 = turn;
            S2 = -turn;
            wheel[0].transform.Rotate(Vector3.up * MSpeed * S1 * Time.deltaTime * control * WheelMultiplier);
            wheel[1].transform.Rotate(Vector3.up * MSpeed * S1 * Time.deltaTime * control * WheelMultiplier);
            wheel[2].transform.Rotate(Vector3.up * MSpeed * S2 * Time.deltaTime * control * WheelMultiplier);
            wheel[3].transform.Rotate(Vector3.up * MSpeed * S2 * Time.deltaTime * control * WheelMultiplier);
            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }

        if (FieldCentering)
        {
            RotPoint.transform.Rotate(0, turn * MSpeed / 4 * -3, 0);
        }
        else
        {
            transform.Rotate(0, turn * MSpeed / 4 * -3, 0);
        }

        transform.Translate(Vector3.right * x * MSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * y * MSpeed * Time.deltaTime);
    }

    public void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x * y != 0)
        {
            control += 10;
        }
        else
        {
            control = 50;
        }

        turn = Input.GetAxisRaw("turn");
    }
}
