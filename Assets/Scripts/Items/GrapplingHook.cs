using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
	[SerializeField] private Camera camera;
	[SerializeField] private LineRenderer lineRenderer;
	[SerializeField] private DistanceJoint2D distanceJoint2D;
	[SerializeField] private Player player;
	[SerializeField] private GameObject hook;

	private bool canMovePlatform = false;
	private bool isHooked = false;

	private void Start()
	{
		distanceJoint2D.enabled = false;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0) && !player.IsGrounded() && hook.GetComponent<GrappleHookHoverDetector>().getHoverFlag())
		{
			Vector2 mousePosition = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition);
			lineRenderer.SetPosition(0, mousePosition);
			lineRenderer.SetPosition(1, transform.position);
			distanceJoint2D.connectedAnchor = mousePosition;
			distanceJoint2D.enabled = true;
			lineRenderer.enabled = true;
			isHooked = true;
		}
		else if(Input.GetKeyUp(KeyCode.Mouse0))
		{
			distanceJoint2D.enabled = false;
			lineRenderer.enabled = false;
			isHooked = false;
		}
		if(distanceJoint2D.enabled)
		{
			lineRenderer.SetPosition(1, transform.position);
		}

		if(isHooked && player.getMovingFlag())
			canMovePlatform = true;
		else
			canMovePlatform = false;
	}

	public bool getMovePlatformFlag()
	{
		return canMovePlatform;
	}
}
