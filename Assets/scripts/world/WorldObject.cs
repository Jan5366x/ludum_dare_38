﻿using Assets.scripts.world;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldObject : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public List<IWorldAction> getWorldActions() {
        return new List<IWorldAction>(GetComponents<IWorldAction>());
    }
  

}
