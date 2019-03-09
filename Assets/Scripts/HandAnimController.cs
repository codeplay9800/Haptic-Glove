using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimController : MonoBehaviour {

	[Range(0,1)]
	public float animationRange;

	public GameObject go;
  	public AnimationClip anim;
 	public Transform[] children;


 	Quaternion[] initRotations;
	Quaternion[] finalRotations;
	// Use this for initialization
	void Start () {

		//children = go.GetComponentsInChildren<Transform>();

		initRotations = new Quaternion[3];
		finalRotations = new Quaternion[3];
		anim.SampleAnimation (go, 0);
	
		for (int i = 0; i < children.Length; i++) {
			initRotations [i] = children [i].rotation;
		}

		anim.SampleAnimation (go, anim.length);
		for (int i = 0; i < children.Length; i++) {
			finalRotations [i] = children [i].rotation;
		}

		for (int i = 0; i < children.Length; i++) {
			Debug.Log ("initial: " + initRotations [i] + "   final: " + finalRotations [i]);
		}


	}

	Quaternion instantaneousRotation;

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 3; i++) {
			instantaneousRotation = Quaternion.Lerp (finalRotations[i], initRotations[i],  animationRange);
			children[i].transform.rotation = Quaternion.Lerp (children[i].transform.rotation, instantaneousRotation,  Time.deltaTime*30);

			//children[i].transform.rotation = Quaternion.Lerp (initRotations[i], finalRotations[i],  Mathf.Abs(Mathf.Sin(Time.time)));
		}
	}
}
