using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticlesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Invinsability.isInvinsable == true)
        {
            StartCoroutine(InvinsableMode());
        }
    }

    public IEnumerator InvinsableMode()
    {
        gameObject.tag = "Untagged";
        GetComponent<Collider>().isTrigger = true;
        yield return new WaitForSeconds(10f);
        gameObject.tag = "Obsticle";
        GetComponent<Collider>().isTrigger = false;
        Invinsability.isInvinsable = false;
    }
}
