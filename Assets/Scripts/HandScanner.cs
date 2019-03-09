using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScanner : MonoBehaviour {
	bool up,nottouch;
	public Animator doorcontrol;
	// Use this for initialization
	void Start () {
		up = false;
		nottouch = true;
	}
	void OnTriggerEnter(Collider col)
	{	if (up == false&&nottouch==true) {
			doorcontrol.SetBool ("Up", true);
			up = true;
			nottouch = false;
		}
		if (up == true&& nottouch==true) {
			doorcontrol.SetBool ("Down", false);
		}
	}
	void OnTriggerExit(Collider col)
	{	
		nottouch = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
