using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float acceleration; // tu nay dich ra la gia toc, tang speed len 5% moi lan update

    float randomX, randomY;

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

    private void FixedUpdate()
    {
        if(obj.transform.position.x < -12f)
        {
            CreateCloud();
        }

    }

    void CreateCloud()
    {
        randomX = Random.Range(11, 15);
        randomY = Random.Range(-20, 20);
        obj.transform.position = new Vector3(randomX, randomY, obj.transform.position.z);
    }
}
