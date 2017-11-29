using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform start;
	public Transform goal;

	public static GameManager Instance { get { return _instance; } }
 
	private static GameManager _instance;

	void Awake()
	{
		if (_instance != null && _instance != this)
			Destroy(gameObject);
		else
			_instance = this;
	}
	
	void Start () {
		
	}
	
	void Update () {
		
	}
	
}
