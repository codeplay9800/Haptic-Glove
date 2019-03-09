using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour {

	public GameObject wall;

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Player")){
			Destroy (wall.gameObject);
			this.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
