using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
	public Animator Star;

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			Star.SetFloat("Direction", -1f);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			Star.SetFloat("Direction", 1f);
		}
	}
}
