using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivatePowerUps : MonoBehaviour {

	public GameObject[] powers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void deactivate () {
		foreach (GameObject p in powers) {
			p.SetActive (false);
		}
	}
}
