using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonar : MonoBehaviour {

	public bool isActive = true;

	public float minTime = 2, minDistance = 2;
	public AudioClip beep, boop;
	AudioSource source;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		Invoke ("emit", minTime);
	}
	
	// Update is called once per frame
	void emit () {
		RaycastHit hit;
		Ray sonarRay = new Ray (gameObject.transform.position, gameObject.transform.forward);

		if (isActive) {
			Debug.Log ("dfsdf");
			Debug.Log (sonarRay.direction);
			if (Physics.Raycast (sonarRay, out hit, 100)) {
				//play sound
				Debug.Log ("beep");
				if (hit.collider.tag.Equals ("key")) {
					source.PlayOneShot (beep);
				} else {
					source.PlayOneShot (boop);
				}
				//source.PlayOneShot (beep);

				if (hit.distance > minDistance) {
					Invoke ("emit", minTime);	
				} else {
					Invoke ("emit", (hit.distance / minDistance) * minTime);	
				}
			} else {
				Invoke ("emit", minTime);	

			}
		}
	}


}
