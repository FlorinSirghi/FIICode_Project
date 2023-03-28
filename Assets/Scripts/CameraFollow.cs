using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private GameObject target;

	private void Update()
	{
		Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, -10.0f);
		transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
	}
}
