using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinit : MonoBehaviour {
    public bool clockwise = true;
    public float speedx = 1.0f;
    private Vector3 direction;
    // Use this for initialization
    public void Reverse() {
        clockwise = !clockwise;
    }
	void Start () {
        direction = Vector3.forward;
        if (clockwise) {
            direction = Vector3.back;
        }
    }

	// Update is called once per frame
	void Update () {
        transform.Rotate(direction, speedx * Time.deltaTime);
    }
}
