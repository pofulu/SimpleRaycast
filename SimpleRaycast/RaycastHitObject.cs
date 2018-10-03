using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastHitObject : MonoBehaviour, IRaycastHitable
{
	public UnityEvent onRaycastHitEnter;
	public UnityEvent onRaycastHitExit;
	public UnityEvent onRaycastHitStay;

	public void OnRaycastHitEnter(GameObject source)
	{
		onRaycastHitEnter.Invoke();
	}

	public void OnRaycastHitExit(GameObject source)
	{
		onRaycastHitExit.Invoke();
	}

	public void OnRaycastHitStay(GameObject source)
	{
		onRaycastHitStay.Invoke();
	}
}
