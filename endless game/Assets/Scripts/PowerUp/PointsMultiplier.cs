using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMultiplier : MonoBehaviour
{
    public static bool isMultipling;
    public GameObject PointsMultiplierobj;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        isMultipling = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //dobule points poweup
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isMultipling = true;
            Destroy(PointsMultiplierobj);
        }
        
    }

    //invinsability PowerUp
    
}