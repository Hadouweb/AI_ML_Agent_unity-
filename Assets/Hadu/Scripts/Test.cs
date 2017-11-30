using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(transform.position, transform.position + Vector3.up * 1, Color.blue, 200f);
		Debug.Log("velocity: " + rb.velocity);
	}
}
