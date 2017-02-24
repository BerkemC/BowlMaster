using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public bool isStanding(){
		if(gameObject) {
			Vector3 rot = transform.rotation.eulerAngles;

			float rotX = 360f - Mathf.Abs (rot.x);
			float rotZ = Mathf.Abs (rot.z);
			if (rotX < standingThreshold && (rotZ % 360f) < standingThreshold) {
				return true;
			}
		}
		return false;
	}
}
