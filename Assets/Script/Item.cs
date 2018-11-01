using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string weaponType;
    public float velocity;
    public float liveTime;

    public Item()
    {
        this.weaponType = "";
        this.velocity = 0;
        this.liveTime = 0f;
    }

	// Use this for initialization
    public Item(string weaponType, float velocity, float liveTime)
    {
        this.weaponType = weaponType;
        this.velocity = velocity;
        this.liveTime = liveTime;
    }

	public void Start () 
    {
        Destroy(this.gameObject, liveTime);
    }
	
	// Update is called once per frame
	public void FixedUpdate () 
    {
        transform.Translate(new Vector3(0, 1, 0) * velocity);
    }

    // Behavior after triggering this item
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }*/
}
