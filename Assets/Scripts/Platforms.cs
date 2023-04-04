using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Transform platform;
    public float Distance;
    public float Speed;

    public float limitTime;

    private float timer = 0f;

    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin(Time.time * Speed) * Distance;

        if(timer >= limitTime)
        {
            Debug.Log("is dowing...");
            transform.position = new Vector3(transform.position.x, initPosition.y - y, transform.position.z);

            if (timer >= limitTime * 2)
            {
                timer = 0f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else {
            transform.position = new Vector3(transform.position.x, initPosition.y + y, transform.position.z);

        }
    }
}
