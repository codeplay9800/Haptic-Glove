using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	public Animator doorcontrol;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
			{
			doorcontrol.SetBool ("Up", true);
			doorcontrol.SetBool ("Down", false);
			}
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			doorcontrol.SetBool ("Down", true);
			doorcontrol.SetBool ("Up", false);
		}
	}

}
