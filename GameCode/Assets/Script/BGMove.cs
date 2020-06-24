using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float acceleration; // tu nay dich ra la gia toc, tang speed len 5% moi lan update


    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        speed = 1.5f;
        maxSpeed = 6f;
        acceleration = 1.0003f;
    }

    // Update is called once per frame
    void Update()
    {

        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
        else
        {
            speed = speed * acceleration;
        }
        obj.transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));

    }
}
