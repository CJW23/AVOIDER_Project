using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed = 5;

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 0) * speed;
	}
}
