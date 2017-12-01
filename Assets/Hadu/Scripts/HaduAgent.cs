using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaduAgent : Agent
{
	private Rigidbody rb;
	private float timer = 0f;
	private Dictionary<Vector3, int> memoryMap;
	
	public override void InitializeAgent()
	{
		rb = GetComponent<Rigidbody>();
		gameObject.transform.position = GameManager.Instance.start.position;
		gameObject.transform.rotation = GameManager.Instance.start.rotation;
		memoryMap = new Dictionary<Vector3, int>();
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
		
		Vector3 vel = new Vector3(actionX, rb.velocity.y, actionZ);
			
		rb.velocity = vel;
		
		//if (rb.velocity.magnitude > 3)
		//	reward -= 0.1f;

		float dist1 = Vector3.Distance(transform.position, 
			GameManager.Instance.goal.transform.position);
		float dist2 = Vector3.Distance(transform.position,
			GameManager.Instance.miniGoal.transform.position);

		/*if (done == false)
		{
			reward += 0.1f;
		}*/

		if (transform.position.y < 0f)
		{
			reward = -0.1f;
			done = true;
		}


		if (rb.velocity.magnitude < 1f)
			reward = -0.01f;
		
		if (dist1 < 1f)
			reward = 1f;
		else if (dist2 < 1f)
			reward = 0.1f;
		/*else
		{
			reward = -(Mathf.Clamp(dist1, 0, 100) / 1000);
		}*/

		//if (timer % 1 == 0)
		//	reward = 0.01f;
		//timer += Time.deltaTime;
	}

	public override void AgentReset()
	{
		gameObject.transform.position = GameManager.Instance.start.position;
		gameObject.transform.rotation = GameManager.Instance.start.rotation;
		memoryMap = new Dictionary<Vector3, int>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public override void AgentOnDone()
	{

	}
}
