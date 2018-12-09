using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{


    public float distance;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float startTimeBtwShots = 2;
    private float timeBtwShots;
    bool shoot = false;

    int counter;


    // Use this for initialization
    public override void Start()
    {
        base.Start();
        timeBtwShots = startTimeBtwShots;
        counter = 1;


    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(shoot + "shoot");
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 4)
        {

            shoot = true;

        }
        if (shoot)
        {

            Vector3 playerDir = player.transform.position - transform.position;

            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg - 90);
            transform.Translate(Vector3.Normalize(playerDir) * Time.deltaTime * speed, Space.World);
            if (timeBtwShots <= 0)
            {
                Shoot();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }




        }


    }


    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        timeBtwShots = startTimeBtwShots;

    }
}
