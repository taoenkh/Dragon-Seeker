using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArrow : MonoBehaviour {


    public float velocity;
    private GameObject player;
    private Vector3 playerDir;
    private float liveTime = 2f;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, liveTime);
        player = GameObject.Find("Player");
        playerDir = player.transform.position - transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2((player.transform.position - transform.position).y, (player.transform.position - transform.position).x) * Mathf.Rad2Deg - 90);         transform.Translate(Vector3.Normalize(player.transform.position - transform.position) * Time.deltaTime * velocity, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }

    }
}
