using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount < 0)
        {
            Debug.Log(Input.GetTouch(0).position);//the input. touch thing is basically it tells u the info for the touch depending on what you put.
            //if we put gettouch(0) then we are finding out the info of the first touch. I put GetTouch.(0).position that means i am getting the position of the first touch.
        }
    }

}
