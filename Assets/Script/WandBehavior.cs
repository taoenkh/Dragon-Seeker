using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandBehavior : MonoBehaviour {

    public float velocity;

    public float liveTime = 1f;


    void Start () {
        Destroy(this.gameObject, liveTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
