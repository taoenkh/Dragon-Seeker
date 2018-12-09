using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spikeTrap: Unit
{

	bool isActivate;
	float _t;
    private Material open_material;
    private Material close_material;
    private AudioClip spikeSound;
	bool hasAttacked = false;

    // Use this for initialization
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        isActivate = false;
        _t = 0f;
        gameObject.GetComponent<Renderer>().material.color = Color.black;

        open_material = Resources.Load("Spike", typeof(Material)) as Material;
        close_material = Resources.Load("SpikeClose", typeof(Material)) as Material;
    }

	
	// Update is called once per frame
	void Update () {

		_t += Time.deltaTime;

		if (_t >= 2 && !isActivate)
		{
			isActivate = true;
            GetComponent<Renderer>().material = open_material;
            _t = 0f;
			gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
		if (_t >= 2 && isActivate)
		{
			isActivate = false;
			hasAttacked = false;
            GetComponent<Renderer>().material = close_material;
            _t = 0f;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
	}
    
    private void OnTriggerEnter(Collider other) {
        //Debug.Log("entered"); 
        
        if (other.gameObject.CompareTag("Player") && isActivate ) {
			hasAttacked = true;
            spikeSound = other.gameObject.GetComponent<PlayerController>().spikeSound;
            other.gameObject.GetComponent<PlayerController>().dmg = (other.gameObject.GetComponent<PlayerController>().dmg + 19);
            other.gameObject.GetComponent<PlayerController>().decrease_hp();
            AudioSource.PlayClipAtPoint(spikeSound, transform.position);
            other.gameObject.GetComponent<PlayerController>().show_hp();
            other.gameObject.GetComponent<PlayerController>().reduce_hpbar();
            other.gameObject.GetComponent<PlayerController>().dmg = (other.gameObject.GetComponent<PlayerController>().dmg - 19);
        }
    }

	private void OnTriggerStay(Collider other){
		if (other.gameObject.CompareTag("Player") && isActivate && !hasAttacked)
        {
			hasAttacked = true;
            spikeSound = other.gameObject.GetComponent<PlayerController>().spikeSound;
            other.gameObject.GetComponent<PlayerController>().dmg = (other.gameObject.GetComponent<PlayerController>().dmg + 19);
            other.gameObject.GetComponent<PlayerController>().decrease_hp();
            AudioSource.PlayClipAtPoint(spikeSound, transform.position);
            other.gameObject.GetComponent<PlayerController>().show_hp();
            other.gameObject.GetComponent<PlayerController>().reduce_hpbar();
            other.gameObject.GetComponent<PlayerController>().dmg = (other.gameObject.GetComponent<PlayerController>().dmg - 19);
        }
	}
}
