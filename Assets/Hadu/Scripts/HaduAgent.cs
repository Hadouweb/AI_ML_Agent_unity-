using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaduAgent : Agent
{
	private Rigidbody rb;
	private float previousDist;
	
	public override void InitializeAgent()
	{
		previousDist = Vector3.Distance(transform.position, GameManager.Instance.goal.transform.position);
		rb = GetComponent<Rigidbody>();
		gameObject.transform.position = GameManager.Instance.start.position;
		gameObject.transform.rotation = GameManager.Instance.start.rotation;
	}

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();

		state.Add(transform.position.x);
		state.Add(transform.position.z);
		
		return state;
	}

	public override void AgentStep(float[] act)
	{
		float actionX = act[0];
		float actionZ = act[1];
		
		Vector3 pos = new Vector3(
			gameObject.transform.position.x + actionX,
			gameObject.transform.position.y,
			gameObject.transform.position.z + actionZ);

		gameObject.transform.position = pos;

		float dist = Vector3.Distance(transform.position, GameManager.Instance.goal.transform.position);

		if (dist < 1f)
		{
			done = true;
			reward = 1f;
		}

		if (dist > 50f)
		{
			reward = -1f;
		}
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
