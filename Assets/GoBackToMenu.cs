﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

            if (Input.GetKey(KeyCode.Escape))
            {

                Application.LoadLevel("main_menu"); // it number or name, string
                  
            }

    }
}
