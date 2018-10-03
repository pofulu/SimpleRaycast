using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastHitDemo : MonoBehaviour
{
	public Text[] demoTexts;

	private void Update()
	{
		foreach (var demoText in demoTexts)
		{
			var color = demoText.color;
			color.a = Mathf.Clamp(color.a -= Time.deltaTime * 2, 0, 1);
			demoText.color = color;
		}
	}

	public void HighligthText(int i)
	{
		var color = demoTexts[i].color;
		color.a = 1.0f;
		demoTexts[i].color = color;
	}
}
