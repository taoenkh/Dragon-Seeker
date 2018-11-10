using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class marshTrap : Unit
{
    
    public override void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    void Update(){}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("entered"); 

        if (other.gameObject.CompareTag("Player") && !(other.gameObject.GetComponent<PlayerController>().isSlowDown))
        {
            other.gameObject.GetComponent<PlayerController>().speed = 1.5f;
            other.gameObject.GetComponent<PlayerController>().isSlowDown = true;
        }
    }
}
