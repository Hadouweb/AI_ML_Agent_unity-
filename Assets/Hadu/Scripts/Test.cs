using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	private Rigidbody rb;
	private Vector3 previousPos;

	void Awake()
	{
		gameObject.transform.position = GameManager.Instance.start.position;
		gameObject.transform.rotation = GameManager.Instance.start.rotation;
	}
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(previousPos, transform.position, Color.blue, 200f);
		Debug.Log("velocity: " + rb.velocity.magnitude);
		previousPos = transform.position;
	}
}
