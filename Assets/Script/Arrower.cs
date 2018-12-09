using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrower : Enemy
{

    public int hp;
    public int dmg;
    public float distance;
    private float timecountattack;

    public bool isHit;
    private Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float startTimeBtwShots = 2;
    private float timeBtwShots;
    private Material n_material;
    private Material blood_material;
    bool shoot = false;


    // Use this for initialization


    public void decrease_hp()
    {
        hp = hp - dmg;
        if (hp < 0) hp = 0;
        //Debug.Log("called "+hp.ToString() + " blodd");
    }

    public override void Start()
    {
        hp = 4;
        base.Start();
        isHit = false;
        timeBtwShots = startTimeBtwShots;
        timecountattack = 0f;
        n_material = Resources.Load("Arrower", typeof(Material)) as Material;
        blood_material = Resources.Load("Arrowergothit", typeof(Material)) as Material;


    }
    private void Update()
    {

        if (isHit && timecountattack >= 0 && timecountattack <= 0.5)
        {
            timecountattack += Time.deltaTime;
            GetComponent<Renderer>().material = blood_material;
        }

        if (isHit && timecountattack > 0.5)
        {
            timecountattack = 0f;
            isHit = false;
            GetComponent<Renderer>().material = n_material;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //aDebug.Log(shoot + "shoot");
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 10)
        {

            shoot = true;

        }
        if (shoot)
        {
            if (distance > 1.5)
            {
                Vector3 playerDir = player.transform.position - transform.position;

                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg - 90);
                //transform.Translate(Vector3.Normalize(playerDir) * Time.deltaTime * speed, Space.World);
            }
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
