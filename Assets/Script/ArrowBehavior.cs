﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{

    public float velocity;

    public float liveTime = 2f;

    void Start()
    {
        Destroy(this.gameObject, liveTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.Translate(new Vector3(-(float)1, 0, 0) * velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
			Debug.Log("opps");
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
			Debug.Log("opps");

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
			Destroy(this.gameObject);

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
