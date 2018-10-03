using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRaycastHitable
{
	void OnRaycastHitStay(GameObject source);
	void OnRaycastHitEnter(GameObject source);
	void OnRaycastHitExit(GameObject source);
}

public class RaycastHitSource : MonoBehaviour
{
	public Transform from;
	public Transform to;
	public float distance = Mathf.Infinity;
	public LayerMask hitableLayer;

	[SerializeField]
	private bool debug;
	[SerializeField]
	private Color debugColor = Color.white;
	private IRaycastHitable currentHit;

	public Ray Ray
	{
		get
		{
			return new Ray(from.position, to.position - from.position);
		}
	}

	private void Start()
	{
		from = Camera.main.transform;
		to = transform;
	}

	private void Update()
	{
		RaycastHit hit;
		if (Physics.Raycast(Ray, out hit, distance, hitableLayer))
		{
			if (hit.collider.GetComponent<IRaycastHitable>() != null)
			{
				var hitObject = hit.collider.GetComponent<IRaycastHitable>();

				if (hitObject != currentHit)
				{
					hitObject.OnRaycastHitEnter(gameObject);
					currentHit = hitObject;
				}
				else
				{
					hitObject.OnRaycastHitStay(gameObject);
				}
			}
		}
		else
		{
			if (currentHit != null)
			{
				currentHit.OnRaycastHitExit(gameObject);
				currentHit = null;
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (debug)
		{
			var validDebugDistance = distance == Mathf.Infinity ? 99999 : distance;
			Gizmos.color = debugColor;
			Gizmos.DrawRay(Ray.origin, Ray.direction * validDebugDistance);
		}
	}
}
