using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenTrap : Unit {

    private AudioClip iceSound;
    // Use this for initialization
    public override void Start () {
        base.Start();

    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Player") && !(other.gameObject.GetComponent<PlayerController>().isFrozen))
        {
			iceSound = other.gameObject.GetComponent<PlayerController>().iceSound;
            other.gameObject.GetComponent<PlayerController>().speed = 0;
            AudioSource.PlayClipAtPoint(iceSound, transform.position);
            other.gameObject.GetComponent<PlayerController>().isFrozen = true;
        }
    }
}
