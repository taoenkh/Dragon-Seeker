using System.Collections;
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
        transform.Translate(new Vector3(0, (float)0.5, 0) * velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.CompareTag("Obstacle"))
        {
            print("ummmm");
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            print("ya-ha");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
