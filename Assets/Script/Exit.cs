using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : Unit
{
    public bool isActive;

    Scene m_Scene;

    // Use this for initialization
    public override void Start () {
        base.Start();
        this.isActive = false;
        SC = GameObject.Find("SceneController");
        gameObject.GetComponent<Renderer>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {


        m_Scene = SceneManager.GetActiveScene();

        if (!isActive){
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                gameObject.GetComponent<Renderer>().enabled = true;
                isActive = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("entered");

            if (other.gameObject.CompareTag("Player"))
        {
            if (m_Scene.name == "MainScene")
            {
                SC.GetComponent<SceneController>().ToStage2();
            }
            else if (m_Scene.name == "Stage2")
            {
                SC.GetComponent<SceneController>().ToStage3();
            }
            else if (m_Scene.name == "Stage3")
            {
                SC.GetComponent<SceneController>().WinScene();
            }
        }
    }
}
