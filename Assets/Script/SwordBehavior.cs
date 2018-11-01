using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour {

    public float velocity;

    public float liveTime = 0.3f;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, liveTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(1, 0, 1), 0.01f);
        transform.Translate(new Vector3(0, (float)0.5, 0) * velocity);
    }

    private void OnTriggerEnter(Collider other)
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
    }
}
