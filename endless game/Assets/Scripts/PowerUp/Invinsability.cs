using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invinsability : MonoBehaviour
{
    public GameObject InvinsabilityObj;
    public static bool isInvinsable;
    // Start is called before the first frame update
    void Start()
    {
        isInvinsable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInvinsable = true;
            Destroy(InvinsabilityObj);
        }
        
    }
}
