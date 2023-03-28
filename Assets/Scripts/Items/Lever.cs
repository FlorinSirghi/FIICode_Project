using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	[SerializeField] private GameObject platform;

	const string SWITCHED = "Switched"; 

	Animator animator;

	bool switched = false;
	float speed = 2.2f;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if(switched)
		{
			platform.transform.position += Vector3.up * Time.deltaTime * speed;
		}
	}

	public void leverSwitched()
	{
		animator.SetBool(SWITCHED, true);
		switched = true;
	}
}
