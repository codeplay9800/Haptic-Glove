using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpManager : MonoBehaviour {

	public int powerIndex = 0;
	public bool isClosed = false;
	public Material handMat;
	Color c;
	// Use this for initialization
	void Start () {
		c = handMat.color;
	}
	
	// Update is called once per frame
	void Update () {
 	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.CompareTag ("index")) {
			isClosed = true;
		}

		if (isClosed) {
			if (col.gameObject.CompareTag ("0")) {
				powerIndex = 0;
				handMat.color = Color.red;
			}
			if (col.gameObject.CompareTag ("1")) {
				powerIndex = 1;
				handMat.color = Color.blue;

			}
			if (col.gameObject.CompareTag ("2")) {
				powerIndex = 2;
				handMat.color = Color.green;

			}
			if (col.gameObject.CompareTag ("3")) {
				powerIndex = 3;
				handMat.color = Color.yellow;

			}
			Debug.Log (powerIndex);
		}
	}
		

	void OnTriggerExit(Collider col){
		if (col.gameObject.CompareTag ("index")) {
			isClosed = false;
		}
	}

	void OnApplicationQuit(){
		handMat.color = c;
	}

}
