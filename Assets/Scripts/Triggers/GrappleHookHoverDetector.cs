using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHookHoverDetector : MonoBehaviour
{
	private bool hover;

	private void OnMouseOver()
	{
		hover = true;
	}

	private void OnMouseExit()
	{
		hover = false;
	}

	public bool getHoverFlag()
	{
		return hover;
	}
}
