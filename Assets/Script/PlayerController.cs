﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Unit
{

    //variables used for shooting
    public GameObject bulletPrefab;
    public GameObject bowHolder;
    public GameObject swordHolder;
    public GameObject wandHolder;
    public AudioClip wandPickup;
    public AudioClip swordPickup;
    public AudioClip bowPickup;
    public AudioClip wandFire;
    public AudioClip swordFire;
    public AudioClip bowFire;
    public AudioClip spikeSound;
    public AudioClip iceSound;
    private GameObject pre_weapon;
    private GameObject pre_object;
    private float fireinterval;
    private Transform bulletSpawn;
    private float lfireTime;

    public Slider hpbar;
    public Text hpText;
    private int hp;
    public int dmg;

    private Material p_material;
    private Material f_material;
    private Material objColor;

    public bool isSlowDown;
    public float timeCountS;

    public bool isFrozen;
    public float timeCountF;

    public void set_hpbar()
    {
        hpbar.minValue = 0;
        hpbar.maxValue = 100;
        hpbar.value = hpbar.maxValue;
    }
    public void reduce_hpbar()
    {
        hpbar.value = hpbar.value - dmg;
    }

    // Use this for initialization
    public override void Start()
    {
        bowHolder.SetActive(false);
        swordHolder.SetActive(false);
        wandHolder.SetActive(false);
        hp = 100;
        if (dmg <= 0)
        {
            dmg = 10;
        }

        set_hpbar();
        show_hp();
        SC = GameObject.Find("SceneController");

        isSlowDown = false;
        timeCountF = 0f;
    
        isFrozen = false;
        timeCountS = 0f;

        objColor = gameObject.GetComponent<Renderer>().material;
        p_material = Resources.Load("Poison", typeof(Material)) as Material;
        f_material = Resources.Load("Frozen", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        //Player shoot
        if (swordHolder.active || bowHolder.active || wandHolder.active)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Time.time - lfireTime > fireinterval)
                {
                    if (swordHolder.active)
                    {
                        AudioSource.PlayClipAtPoint(swordFire, transform.position);
                    }
                    else if (bowHolder.active)
                    {
                        AudioSource.PlayClipAtPoint(bowFire, transform.position);
                    }
                    else if (wandHolder.active)
                    {
                        AudioSource.PlayClipAtPoint(wandFire, transform.position);
                    }
                    lfireTime = Time.time;
                    bulletSpawn = this.gameObject.transform.GetChild(2);
                    shoot();
                }

            }
        }
        if (hp <= 0)
        {
            SC.GetComponent<SceneController>().GameOver.Invoke();
        }

        if (isSlowDown)
        {
            timeCountS += Time.deltaTime;
            GetComponent<Renderer>().material = p_material;
            if (timeCountS >= 2.5)
            {
                timeCountS = 0f;
                isSlowDown = false;
                speed = 3;
                GetComponent<Renderer>().material = objColor;
            }
        }

        if (isFrozen)
        {
            timeCountF += Time.deltaTime;
            GetComponent<Renderer>().material = f_material;
            if (timeCountF >= 1.5)
            {
                timeCountF = 0f;
                isFrozen = false;
                speed = 3;
                GetComponent<Renderer>().material = objColor;
            }
        }
    }


    void FixedUpdate()
    {

        // Movement action
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Make sure the player moves along the global axis, not its local one
        transform.Translate(new Vector3(x, 0, 0), Space.World);
        transform.Translate(new Vector3(0, y, 0), Space.World);


    }

    private void OnTriggerStay(Collider other)
    {
        //If player hit the wall, prevent further movement
        if (other.gameObject.CompareTag("Obstacle"))
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(new Vector3(-x, 0, 0), Space.World);
            transform.Translate(new Vector3(0, -y, 0), Space.World);
        }

        //Player pick up an item
        else if (Input.GetKey(KeyCode.Space))
        {
            bulletPrefab = other.GetComponent<ItemHolder>().info.bulletObject;
            fireinterval = other.GetComponent<ItemHolder>().info.fireinterval;
            if (other.gameObject.name == "Bow")
            {
                bowHolder.SetActive(true);
                AudioSource.PlayClipAtPoint(bowPickup, transform.position);
                if (pre_object != null)
                {
                    pre_object.SetActive(false);
                    pre_object = bowHolder;
                }
                else
                    pre_object = bowHolder;

            }
            else if (other.gameObject.name == "Sword")
            {
                swordHolder.SetActive(true);
                AudioSource.PlayClipAtPoint(swordPickup, transform.position);
                if (pre_object != null)
                {
                    pre_object.SetActive(false);
                    pre_object = swordHolder;
                }
                else
                    pre_object = swordHolder;
            }
            else if (other.gameObject.name == "Wand")
            {
                wandHolder.SetActive(true);
                AudioSource.PlayClipAtPoint(wandPickup, transform.position);
                if (pre_object != null)
                {
                    pre_object.SetActive(false);
                    pre_object = wandHolder;
                }
                else
                    pre_object = wandHolder;
            }
            other.gameObject.SetActive(false);
            if (pre_weapon != null)
            {
                pre_weapon.SetActive(true);
                pre_weapon = other.gameObject;
            }
            else
                pre_weapon = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            decrease_hp();
            show_hp();
            reduce_hpbar();
        }
    }

    private void shoot()
    {
        GameObject obj = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		obj.transform.localScale = obj.transform.localScale * 2;
    }

    public void decrease_hp()
    {
        hp = hp - dmg;
        AudioSource.PlayClipAtPoint(spikeSound, transform.position);
        if (hp < 0) hp = 0;
        //Debug.Log("called "+hp.ToString() + " blodd");
    }

    public void increase_hp()
    {
        hp = hp + dmg;
    }

    public void show_hp()
    {
        hpText.text = "HP: " + hp.ToString();
    }
}