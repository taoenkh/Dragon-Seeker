using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{

    //public GameObject player1;

    public float distance;
    public Transform[] movespots;
    Transform currentPartolPoint;
    int currentPartolIndex;
    bool chase = false;


    // Use this for initialization
    public override void Start()
    {
        base.Start();
        currentPartolIndex = 0;
        currentPartolPoint = movespots[currentPartolIndex];
    }

    // Update is called once per frame
    void Update()
    {


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
                Debug.Log("reached the point");
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
