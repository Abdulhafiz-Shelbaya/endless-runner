using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTest : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = Input.acceleration.x;
        float z = Input.acceleration.z;
//        transform.Translate(temp,0,0);
       transform.Rotate(0,0,temp*speed);
       transform.Translate(0,0,-z);
    }
}
