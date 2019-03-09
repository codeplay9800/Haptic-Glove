using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector3.forward * Time.deltaTime * Input.GetAxis ("Vertical") * 2);
		gameObject.transform.Rotate (Vector3.up * Input.GetAxis ("Horizontal") );
	}
}
