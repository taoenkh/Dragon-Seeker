using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{

    //public GameObject player1;
    public int hp;
    public int dmg = 1;
    private Material attackedMaterial;
    private float timecountattack;
    public float distance;
    public Transform[] movespots;
    Transform currentPartolPoint;
    int currentPartolIndex;
    bool chase = false;
    private Material n_material;
    private Material blood_material;

    public bool isHit;


    // Use this for initialization
    public override void Start()
    {
        base.Start();
        hp = 4;
        currentPartolIndex = 0;

        timecountattack = 0f;
        isHit = false;

        currentPartolPoint = movespots[currentPartolIndex];
        n_material = Resources.Load("Enemy", typeof(Material)) as Material;
        blood_material = Resources.Load("Enemygothit", typeof(Material)) as Material;
    }

    // Update is called once per frame
    public void decrease_hp()
    {
        hp = hp - dmg;
        if (hp < 0) hp = 0;
        //Debug.Log("called "+hp.ToString() + " blodd");
    }


    void Update()
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

    private void FixedUpdate()
    {

        //Debug.Log(currentPartolIndex+ "currentindex");
        //Debug.Log(movespots.Length);
        distance = Vector3.Distance(player.transform.position, transform.position);


        if (distance < 3)
        {
            chase = true;


        }
        if (chase)
        {
            // Zombie chase after the player

            // Change the direction to player
            Vector3 playerDir = player.transform.position - transform.position;

            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg - 90);
            transform.Translate(Vector3.Normalize(playerDir) * Time.deltaTime * speed, Space.World);

        }

        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);


            //Debug.Log(Vector3.Distance(transform.position, currentPartolPoint.position));
            if (Vector3.Distance(transform.position, currentPartolPoint.position) < .1f)
            {
                //Debug.Log("reached the point");
                if (currentPartolIndex + 1 < movespots.Length)
                {
                    //Debug.Log("not full yet");
                    currentPartolIndex++;
                }
                else

                {
                    //Debug.Log("inside else");
                    currentPartolIndex = 0;
                }
                currentPartolPoint = movespots[currentPartolIndex];
            }

            Vector3 patrolPointDir = currentPartolPoint.position - transform.position;
            float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;



            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
        }
    }


}
