using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFiledBehavior : MonoBehaviour {

	private float startTime;

	// Use this for initialization
	void Start () {

		startTime = Time.time;
        
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - startTime >= 1)
			Destroy(this.gameObject);

	}
    
	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Enemy"))
		{

			other.gameObject.GetComponent<Zombie>().dmg = 1;

			other.gameObject.GetComponent<Zombie>().decrease_hp();

			other.gameObject.GetComponent<Zombie>().isHit = true;

			Debug.Log(other.gameObject.GetComponent<Zombie>().hp);
			if (other.gameObject.GetComponent<Zombie>().hp <= 0)
			{


				Destroy(other.gameObject);
			}


		}
		else if (other.CompareTag("Arrower"))
		{

			other.gameObject.GetComponent<Arrower>().dmg = 1;

			other.gameObject.GetComponent<Arrower>().decrease_hp();

			other.gameObject.GetComponent<Arrower>().isHit = true;

			Debug.Log(other.gameObject.GetComponent<Arrower>().hp);
			if (other.gameObject.GetComponent<Arrower>().hp <= 0)
			{


				Destroy(other.gameObject);
			}
		}

	}
}
