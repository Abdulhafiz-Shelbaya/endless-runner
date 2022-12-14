using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class Coin : MonoBehaviour
{

    public Transform playerTransform;
    public float moveSpeed = 17f;

    CoinMove coinMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMoveScript = gameObject.GetComponent<CoinMove>();
        coinMoveScript.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin Detector")
        {
            coinMoveScript.enabled = true;
        }
    }
}
