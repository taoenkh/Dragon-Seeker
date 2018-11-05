using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spikeTrap: Unit
{

	bool isActivate;
	float _t;

    // Use this for initialization
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        isActivate = false;
        _t = 0f;
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

	
	// Update is called once per frame
	void Update () {

		_t += Time.deltaTime;

		if (_t >= 8 && !isActivate)
		{
			isActivate = true;
			_t = 0f;
			gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
		if (_t >= 8 && isActivate)
		{
			isActivate = false;
			_t = 0f;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
	}

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("entered"); 
        
        if (other.gameObject.CompareTag("Player") && isActivate ) {
            other.gameObject.GetComponent<PlayerController>().dmg = (other.gameObject.GetComponent<PlayerController>().dmg + 19);
            other.gameObject.GetComponent<PlayerController>().decrease_hp();
            other.gameObject.GetComponent<PlayerController>().show_hp();
            other.gameObject.GetComponent<PlayerController>().reduce_hpbar();
            other.gameObject.GetComponent<PlayerController>().dmg = (other.gameObject.GetComponent<PlayerController>().dmg - 19);
        }
    } 
}
