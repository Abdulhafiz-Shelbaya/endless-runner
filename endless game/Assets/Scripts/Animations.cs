using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject bob;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 0)
        {
            GetComponent<Animator>().Play("RollRight");
        }
         time = time -= Time.deltaTime;
        if(time < 0)
        {
            GetComponent<Animator>().Play("Sprint");
        }
        
    }
}
