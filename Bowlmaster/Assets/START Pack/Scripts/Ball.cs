using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Rigidbody rigidbody;
	private AudioSource audioSource;
	public bool inPlay = false;
	private Vector3 startPoint;
	private DragLaunch isLaunched;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent <Rigidbody> ();
		audioSource = GetComponent <AudioSource> ();
		rigidbody.useGravity = false;
		startPoint = transform.position;
		isLaunched = GameObject.FindObjectOfType <DragLaunch> ();
	}


	
	// Update is called once per frame
	void Update () {
		
	}
	public void LaunchBall (Vector3 direction)
	{
		rigidbody.useGravity = true;
		rigidbody.velocity = direction;
		audioSource.Play ();
	}
	public void Reset(){
		print ("here");
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
		transform.position = startPoint;
		rigidbody.useGravity = false;
		isLaunched.isLaunched = false;
		inPlay = false;
	}


}
