﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuStart : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changemenuscene()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

}
