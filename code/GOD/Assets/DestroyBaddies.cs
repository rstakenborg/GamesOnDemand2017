﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBaddies : MonoBehaviour {
    public string destroyTag = "Baddie";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col) {
        Destroy(col.gameObject);
        if (col.gameObject.tag == destroyTag) {
            
        }
    }
}
