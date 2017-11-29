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
		//if (Input.GetKeyDown(KeyCode.Z))
		//	rb.AddForce(Vector3.forward * 10);
	}
}
