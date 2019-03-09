using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivationManager : MonoBehaviour {

	Vector3 offset;
	public GameObject hand;
	public Animator[] powers;
	public GameObject[] powerSpheres;
	// Use this for initialization
	void Start () {
		offset = gameObject.transform.position - hand.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = hand.transform.position + offset;

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("palmTracker")) {
			Debug.Log ("Active");
			ActivateSpheres ();
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.CompareTag ("palmTracker")) {
			Debug.Log ("Deactivate");
			DeactivateSpheres ();
		}
	}

	public void ActivateSpheres(){
		foreach (GameObject p in powerSpheres) {
			p.SetActive (true);
		}
		powers [0].SetTrigger ("activate");
		powers [1].SetTrigger ("activate");
		powers [2].SetTrigger ("activate");
		powers [3].SetTrigger ("activate");

	}

	public void DeactivateSpheres(){
		powers [0].SetTrigger ("deactivate");
		powers [1].SetTrigger ("deactivate");
		powers [2].SetTrigger ("deactivate");
		powers [3].SetTrigger ("deactivate");

	}

}
