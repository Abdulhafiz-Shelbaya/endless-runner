using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTester : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began) // if the amount of touches is  greater than 0 OR(the || means or, so like this or that) we have just touched the screen
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);// this code is basically creating a ray from the camera when we do whats inside the perameter(which is GetTouch(0)).
        
             Debug.DrawRay(ray.origin,ray.direction * 20, Color.red); // we are drawing/ showing the ray in the scene. for the perameter we have to give(start vector3, direction vector3,Color) 
                //so it starts at the rays orignal place, then goes 20 units to the direction we touch the screen


            if(Physics.Raycast(ray,out hit, Mathf.Infinity))// if we cast a ray(which is done using the ray = camer.main function above) then it will do the body
            //the perameter(ray{the variable that we are using to activate the if statment}, out hit{when we hit a target with a ray we are getting an output of the gameobject it hits}, mathf.Infinity{ the ray goes on for infanite})
            
            
            
            // this function takes the ray and the distance that the ray can travel and creates the ray from the camera to the touch position.
            //for this function we put 2 variables in the perameter ( we put our variable that contains the ray, and the distance the ray can travel)
            //this function also checks if the ray has hit anything. if it has then it will be true else it will be false.
            {
        
               
            
                Debug.Log("hit something");
                Destroy(hit.transform.gameObject);//when the ray hits a gameobject everything in the gameobject's transform will be destroyed
            }

        }
    }
    
}
