using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandBehavior : MonoBehaviour
{

    public float velocity;

    public float liveTime = 1f;

	public GameObject fireFiledPrefab;



    void Start()
    {
        Destroy(this.gameObject, liveTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.Translate(new Vector3(-(float)1, 0, 0) * velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
			GameObject obj = (GameObject)Instantiate(fireFiledPrefab, transform.position + new Vector3(0, 0, 0.5f), transform.rotation);

            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Arrower"))
        {

			GameObject obj = (GameObject)Instantiate(fireFiledPrefab, transform.position + new Vector3(0, 0, 0.5f), transform.rotation);

			Destroy(this.gameObject);         
        }
    }
}
