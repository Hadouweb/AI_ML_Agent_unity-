using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaduAgent : Agent
{
	private Rigidbody rb;
	
	public override void InitializeAgent()
	{
		rb = GetComponent<Rigidbody>();
		gameObject.transform.position = GameManager.Instance.start.position;
		gameObject.transform.rotation = GameManager.Instance.start.rotation;
	}

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();

		state.Add(Mathf.Abs(transform.position.x - GameManager.Instance.goal.transform.position.x));
		state.Add(Mathf.Abs(transform.position.z - GameManager.Instance.goal.transform.position.z));
		
		return state;
	}

	public override void AgentStep(float[] act)
	{

		if ((int)act[0] > 0)
		{
			rb.AddForce(Vector3.forward * 10);
		}
		else
		{
			rb.AddForce(-Vector3.forward * 10);
		}
		
		if ((int)act[1] > 0)
		{
			rb.AddForce(Vector3.left * 10);
		}
		else
		{
			rb.AddForce(-Vector3.right * 10);
		}

		float dist = Vector3.Distance(transform.position, GameManager.Instance.goal.transform.position);
		
		if (done == false)
		{
			reward = 0.0001f;
		}

		if (dist < 1f)
			reward = 50f;
		
		if (dist > 50f)
		{
			done = true;
			reward = -1f;
		}
		else
			done = false;
	}

	public override void AgentReset()
	{
		gameObject.transform.position = GameManager.Instance.start.position;
		gameObject.transform.rotation = GameManager.Instance.start.rotation;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public override void AgentOnDone()
	{

	}
}
