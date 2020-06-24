using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Start_BGMove : MonoBehaviour
{
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position.x < -9.5f)
        {
            obj.transform.position = new Vector3(9.6f, obj.transform.position.y, transform.position.z);
        }
            
    }
}
